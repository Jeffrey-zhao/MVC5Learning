using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppModelMatedata.Models
{
    /// <summary>
    /// HiddenInput表示没有输入框，数据仍然显示，要想不显示利用ScaffoldColumnAttribute的Scaffold=false
    /// RequiredAttribute的AllowEmptyStrings 对应于ModelMetadata的IsRequired,默认为True
    /// </summary>
    public class DemoModel2
    {
        [HiddenInput]
        public string Foo { get; set; }

        [HiddenInput(DisplayValue =false)]
        public string Bar { get; set; }
        [Required]
        public string Baz { get; set; }
    }
}