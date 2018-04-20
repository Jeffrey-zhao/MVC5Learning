using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppModelMatedata.Models
{
    /// <summary>
    /// UIHint 优先级大于 HiddenInput
    /// 1. Metadata的TemplateHint 对应 HiddenInput
    /// 2. Metadata的 HideSurroundingHtml 对应 HiddenInput的 DisplayValue,只不过取其反
    /// </summary>
    public class DemoModel3
    {
        [HiddenInput]
        public string Foo { get; set; }

        [HiddenInput(DisplayValue =false)]
        public string Bar { get; set; }

        [UIHint("template A")]
        [UIHint("template B","Mvc")]
        public string Baz { get; set; }
    }
}