using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppModelMatedata.Models
{
    /// <summary>
    /// DisplayAttribute 对应于Name的优先级大于DisplayNameAttribute
    /// 1.DisplayAttribute的GetName() 和DisplayNameAttribute的 DisplayName 对应ModelMetadata的 DisplayName
    /// 2.DisplayAttribute的GetShortName() 对应ModelMetadata的 ShortDisplayName
    /// 3.DisplayAttribute的GetDescription() 对应ModelMetadata的 Description
    /// 4.DisplayAttribute的GetPrompt() 对应ModelMetadata的 Watermark
    /// 5.DisplayAttribute的GetOrder() 对应ModelMetadata的 Order (默认为10000)
    /// </summary>
    public class DemoModel6
    {
        public string Foo { get; set; }

        [DisplayName("Bar")]
        public string Bar { get; set; }

        [Display(Name = "BAZ", Description = "Desc", ShortName = "B", Prompt = "Watermark...", Order = 999)]
        [DisplayName("baz")]
        public string Baz { get; set; }
    }
}