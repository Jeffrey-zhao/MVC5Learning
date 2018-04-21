using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
//using System.Web.ModelBinding;
//注意，我之前引用了上面的空间，出错了，为什么不能正确显示的原因呢?
// ModelBinding,Mvc 空间都有 IMetadataAware的接口，原因在查找中

namespace WebAppModelMatedata.Customs
{
    public class ExtendedDataAnnotationProvider : CachedDataAnnotationsModelMetadataProvider
    {
        protected override CachedDataAnnotationsModelMetadata CreateMetadataFromPrototype(CachedDataAnnotationsModelMetadata prototype, Func<object> modelAccessor)
        {
            var modelMetadata= base.CreateMetadataFromPrototype(prototype, modelAccessor);
            modelMetadata.DisplayName = prototype.DisplayName;
            return modelMetadata;
        }

        protected override CachedDataAnnotationsModelMetadata CreateMetadataPrototype(IEnumerable<Attribute> attributes, Type containerType, Type modelType, string propertyName)
        {
            var modelMetadata= base.CreateMetadataPrototype(attributes, containerType, modelType, propertyName);
            if (string.IsNullOrEmpty(modelMetadata.DisplayName))
            {
                DisplayTextNoIMetadataAwareAttribute displayNameAttribute = attributes.OfType<DisplayTextNoIMetadataAwareAttribute>().FirstOrDefault();
                if (null != displayNameAttribute)
                {
                    displayNameAttribute.SetDisplayName(modelMetadata);
                }
            }
            return modelMetadata;
        }
    }
}