using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Reflection;

namespace WebAppMyModelBinder.Customs
{
    public class MyDefaultModelBinder4 : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string prefix = bindingContext.ModelName;
            IValueProvider valueProvider = bindingContext.ValueProvider;
            bool containPrefix = valueProvider.ContainsPrefix(prefix);
            //增加二次绑定的处理
            if (!containPrefix)
            {
                if (!bindingContext.FallbackToEmptyPrefix)
                {
                    return null;
                }
                bindingContext.ModelName = null;
            }
            else
            {
                // bind sample model
                //todo :getValue 为什么返回null
                ValueProviderResult valueProviderResult = valueProvider.GetValue(prefix);
                if (null != valueProviderResult)
                {
                    return this.BindSimpleModel(controllerContext, bindingContext, valueProviderResult);
                }
            }
            if (bindingContext.ModelMetadata.IsComplexType)
            {
                return this.BindComplexModel(controllerContext, bindingContext);
            }
            return null;
        }

        private object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (modelType.IsGenericType)
            {
                Type genericTypeDefinition = modelType.GetGenericTypeDefinition();
                if (new Type[] { typeof(IEnumerable<>), typeof(ICollection<>), typeof(IList<>) }.Any(type => type == genericTypeDefinition))
                {
                    return Activator.CreateInstance(typeof(List<>).MakeGenericType(modelType.GetGenericArguments()));
                }
            }
            return Activator.CreateInstance(modelType);
        }

        private IEnumerable<string> GetIndexes(ControllerContext controllerContext, ModelBindingContext bindingContext, out bool isZeroBased)
        {
            string key = (bindingContext.ModelName ?? "") + ".index";
            key = key.Trim('.');
            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(key);
            if (null != valueProviderResult)
            {
                isZeroBased = false;
                return (string[])valueProviderResult.ConvertTo(typeof(string[]));
            }
            isZeroBased = true;
            return GetZeroBasedIndexes();
        }

        private IEnumerable<string> GetZeroBasedIndexes()
        {
            int index = 0;
            while (true)
            {
                yield return (index++).ToString();
            }
        }
        private object BindCollection(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Type modelType = bindingContext.ModelType;
            Type elementType = modelType.IsArray ? modelType.GetElementType() : modelType.GetGenericArguments()[0];
            Type collectionType = modelType.IsArray ? typeof(List<>).MakeGenericType(elementType) : modelType;
            object model = this.CreateModel(controllerContext, bindingContext, collectionType);
            bindingContext.ModelMetadata.Model = model;

            bool isZeroBased;
            IEnumerable<string> indexes = this.GetIndexes(controllerContext, bindingContext, out isZeroBased);
            List<object> elements = new List<object>();
            foreach (string index in indexes)
            {
                string prefix = string.Format("{0}[{1}]", bindingContext.ModelName, index);
                if (!bindingContext.ValueProvider.ContainsPrefix(prefix))
                {
                    if (isZeroBased)
                    {
                        break;
                    }
                    continue;
                }
                ModelBindingContext context = new ModelBindingContext
                {
                    ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, elementType),
                    ModelName = prefix,
                    ModelState = bindingContext.ModelState,
                    PropertyFilter = bindingContext.PropertyFilter,
                    ValueProvider = bindingContext.ValueProvider
                };
                object element = ModelBinders.Binders.GetBinder(elementType).BindModel(controllerContext, context);
                elements.Add(element);
            }
            this.Copy(elementType, bindingContext.Model, elements);

            if (modelType.IsArray)
            {
                IList list = model as IList;
                if (null == list)
                {
                    return null;
                }
                Array array = Array.CreateInstance(elementType, list.Count);
                list.CopyTo(array, 0);
                return array;
            }
            return model;
        }
        private static void CopyCollection<T>(ICollection<T> destination, IEnumerable source)
        {
            foreach (object item in source)
            {
                destination.Add(item is T ? (T)item : default(T));
            }
        }

        private void Copy(Type elementType, object destination, object source)
        {
            MethodInfo copyMethod = typeof(MyDefaultModelBinder3).GetMethod("CopyCollection", BindingFlags.Static | BindingFlags.NonPublic);
            copyMethod.MakeGenericMethod(elementType).Invoke(null, new object[] { destination, source });
        }
        private bool Match(Type type, Type typeToMatch)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeToMatch)
            {
                return true;
            }
            foreach (Type interfaceType in type.GetInterfaces())
            {
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeToMatch)
                {
                    return true;
                }
            }
            return false;
        }
        private object BindComplexModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Type modelType = bindingContext.ModelType;
            if (this.Match(modelType, typeof(IEnumerable<>)))
            {
                return this.BindCollection(controllerContext, bindingContext);
            }

            object model = this.CreateModel(controllerContext, bindingContext, modelType);
            bindingContext.ModelMetadata.Model = model;// 缺少这句导致下面属性绑定为null的情况
            ICustomTypeDescriptor modelTypeDescriptor = new AssociatedMetadataTypeTypeDescriptionProvider(modelType)
                                                        .GetTypeDescriptor(modelType);
            PropertyDescriptorCollection propertyDescriptors = modelTypeDescriptor.GetProperties();
            foreach (PropertyDescriptor propertyDescriptor in propertyDescriptors)
            {
                this.BindProperty(controllerContext, bindingContext, propertyDescriptor);
            }
            return model;
        }

        private void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
        {
            //属性一直为null，为什么？
            string prefix = (bindingContext.ModelName ?? "") + "." + (propertyDescriptor.Name ?? "");
            prefix = prefix.Trim('.');
            ModelMetadata metadata = bindingContext.PropertyMetadata[propertyDescriptor.Name];
            ModelBindingContext context = new ModelBindingContext
            {
                ModelName = prefix,
                ModelMetadata = metadata,
                ModelState = bindingContext.ModelState,
                ValueProvider = bindingContext.ValueProvider
            };
            // object propertyValue = ModelBinders.Binders.GetBinder(propertyDescriptor.PropertyType).BindModel(controllerContext, context);
            IModelBinder modelBinder = ModelBinders.Binders.GetBinder(propertyDescriptor.PropertyType);
            object propertyValue = modelBinder.BindModel(controllerContext, context);
            if (bindingContext.ModelMetadata.ConvertEmptyStringToNull && object.Equals(propertyValue, string.Empty))
            {
                propertyValue = null;
            }
            context.ModelMetadata.Model = propertyValue;
            propertyDescriptor.SetValue(bindingContext.Model, propertyValue);
        }

        private object BindSimpleModel(ControllerContext controllerContext, ModelBindingContext bindingContext, ValueProviderResult valueProviderResult)
        {
            SetModelState(bindingContext, valueProviderResult);
            Type modelType = bindingContext.ModelType;
            if (typeof(string) != modelType && this.Match(modelType, typeof(IEnumerable<>)))
            {
                Type arrayType = modelType.IsArray ? modelType : modelType.GetGenericArguments()[0].MakeArrayType();
                object array = valueProviderResult.ConvertTo(arrayType);
                if (bindingContext.ModelType.IsArray)
                {
                    return array;
                }
                object list = this.CreateModel(controllerContext, bindingContext, modelType);
                this.Copy(modelType.GetGenericArguments()[0], list, array);
                return list;
            }
            return valueProviderResult.ConvertTo(bindingContext.ModelType);
        }

        private void SetModelState(ModelBindingContext bindingContext, ValueProviderResult valueProviderResult)
        {
            ModelState modelState;
            if (!bindingContext.ModelState.TryGetValue(bindingContext.ModelName, out modelState))
            {
                bindingContext.ModelState.Add(bindingContext.ModelName, modelState = new ModelState());
            }
            modelState.Value = valueProviderResult;
        }
    }
}