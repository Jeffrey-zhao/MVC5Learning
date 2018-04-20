using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebAppHtmlTemplate.Models
{
    public class DemoModel2
    {
        public decimal Foo1 { get; set; }
        public decimal Bar1 { get; set; }

        public bool Foo2 { get; set; }

        public int Foo3 { get; set; }
        public long Bar3 { get; set; }
        public byte Baz3 { get; set; }

        public Color Foor4 { get; set; }
        public object Foor5 { get; set; }

        [DisplayName("姓名")]
        public string Bar5 { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        public string Province { get; set; }
        public string City { get; set; }
    }
}