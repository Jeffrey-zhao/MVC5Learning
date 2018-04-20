using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppModelMatedata.Models
{
    /// <summary>
    /// 1.DisplayFormatAttribute 优先级大于 DataTypeAttribute 中的 DisplayFormatAttribute
    /// 2.若没应用DataTypeAttribute 直接使用 DisplayFormat(HtmlEncode =false)，则DataType 全显示为"html"
    /// 3.DataType 为custom，则DataType显示为 设置值，使用的DataType枚举，则为枚举的ToString()
    /// 4.未设置DataType，则DataType为空
    /// </summary>
    public class DemoModel4
    {
        [DataType(DataType.EmailAddress)]
        public string Foo { get; set; }

        [DataType("Barcode")]
        public string Bar { get; set; }

        public string Baz { get; set; }

        [DisplayFormat(HtmlEncode =false)]
        public string Qux { get; set; }
    }
}