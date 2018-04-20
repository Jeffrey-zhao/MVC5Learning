using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppModelMatedata.Models
{
    /// <summary>
    /// 1.第二参数为Mvc，优先级最高，若未设置，反射默认选择第一个，不一定是申明的顺序
    /// </summary>
    public class DemoModel
    {
        public string Foo { get; set; }
        [UIHint("Template A")]
        [UIHint("Template B","Mvc")]
        public string Bar { get; set; }
        [UIHint("Template A")]
        [UIHint("Template B")]
        public string Baz { get; set; }
    }
}