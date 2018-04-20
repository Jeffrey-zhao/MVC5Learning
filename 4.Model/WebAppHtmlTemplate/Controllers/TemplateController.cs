using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHtmlTemplate.Models;

namespace WebAppHtmlTemplate.Controllers
{
    public class TemplateController : Controller
    {
        // GET: Template
        public ActionResult Index()
        {
            DemoModel model = new DemoModel
            {
                Foo = "<a href='www.google.com'>google.com</a>",
                Bar = "<a href='www.google.com'>google.com</a>",
                Foobar4 = "Hello,jeffrey zhao",
                Foobar5 = "www.baidu.com",
                Foobar6 = "hello<br/>world",
                Foobar7 = "123456",
                Foobar8 = new object[] { 123.00, "dummy text...", true },
                Foobar9 = DateTime.Now,
                Foobar10 = DateTime.Now,
                Foobar11 = DateTime.Now,
                Foobar12 = DateTime.Now,
                Foobar13 = "13171926543"
            };
            return View(model);
        }
    }
}