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
    /// </summary>
    public class DemoModel7
    {
        public string Foo { get; set; }

        [AllowHtml]
        public string Bar { get; set; }

    }
}