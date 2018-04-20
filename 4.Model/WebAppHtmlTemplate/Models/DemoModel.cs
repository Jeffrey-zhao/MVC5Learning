using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppHtmlTemplate.Models
{
    public class DemoModel
    {
        [UIHint("EmailAddress")]
        public string Foobar { get; set; }

        [UIHint("HiddenInput")]
        public string Foobar2 { get; set; }

        [HiddenInput(DisplayValue =false)]
        public string Foobar3 { get; set; }
        [UIHint("Html")]
        public string Foo { get; set; }
        public string Bar { get; set; }

        [UIHint("Text")]
        public string Foobar4 { get; set; }

        [UIHint("Url")]
        public string Foobar5 { get; set; }

        [UIHint("MultilineText")]
        public string Foobar6 { get; set; }

        [UIHint("Password")]
        public string Foobar7 { get; set; }

        [UIHint("Collection")]
        public object[] Foobar8 { get; set; }
        [UIHint("DateTime")]
        public DateTime? Foobar9 { get; set; }
        [UIHint("DateTime-local")]
        public DateTime? Foobar10 { get; set; }
        [UIHint("Date")]
        public DateTime? Foobar11 { get; set; }
        [UIHint("Time")]
        public DateTime? Foobar12 { get; set; }
        [UIHint("PhoneNumber")]
        public string Foobar13 { get; set; }
    }
}