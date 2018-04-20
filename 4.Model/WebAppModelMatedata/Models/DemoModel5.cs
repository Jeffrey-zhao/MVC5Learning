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
    /// Editable 优先级大于 ReadOnly
    /// </summary>
    public class DemoModel5
    {
        [ReadOnly(true)]
        public string Foo { get; set; }

        [ReadOnly(true)]
        [Editable(true)]
        public string Bar { get; set; }

        [ReadOnly(false)]
        [Editable(false)]
        public string Baz { get; set; }        
    }
}