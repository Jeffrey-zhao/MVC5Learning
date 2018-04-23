using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebAppMyModelBinder.Customs
{
    public class MyDefaultModelBinder2 : IModelBinder
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

        private object CreateModel(ControllerContext controllerContext,ModelBindingContext bindingContext,Type modelType)
        {
            return Activator.CreateInstance(modelType);
        }
        private object BindComplexModel(ControllerContext controllerContext,ModelBindingContext bindingContext)
        {
            Type modelType = bindingContext.ModelType;
            object model = this.CreateModel(controllerContext, bindingContext,modelType);

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
            object propertyValue = ModelBinders.Binders.GetBinder(propertyDescriptor.PropertyType).BindModel(controllerContext, context);
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
            return valueProviderResult.ConvertTo(bindingContext.ModelType);
        }

        private void SetModelState(ModelBindingContext bindingContext, ValueProviderResult valueProviderResult)
        {
            ModelState modelState;
            if(!bindingContext.ModelState.TryGetValue(bindingContext.ModelName,out modelState))
            {
                bindingContext.ModelState.Add(bindingContext.ModelName, modelState = new ModelState());
            }
            modelState.Value = valueProviderResult;
        }
    }
}