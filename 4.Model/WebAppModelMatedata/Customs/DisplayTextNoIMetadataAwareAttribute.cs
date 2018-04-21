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
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Property)]
    public class DisplayTextNoIMetadataAwareAttribute : Attribute
    {
        private static Type staticResourceType;
        public string DisplayName { get; set; }
        public Type ResourceType { get; set; }
        public DisplayTextNoIMetadataAwareAttribute()
        {
            this.ResourceType = staticResourceType;
        }
        public static void SetResourceType(Type resourceType)
        {
            staticResourceType = resourceType;
        }
        public void SetDisplayName(ModelMetadata metadata)
        {
            this.DisplayName = this.DisplayName ?? (metadata.PropertyName ?? metadata.ModelType.Name);
            if (null == this.ResourceType)
            {
                metadata.DisplayName = this.DisplayName;
                return;
            }

            PropertyInfo property = this.ResourceType.GetProperty(this.DisplayName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            metadata.DisplayName = property.GetValue(null, null).ToString();
        }
    }
}