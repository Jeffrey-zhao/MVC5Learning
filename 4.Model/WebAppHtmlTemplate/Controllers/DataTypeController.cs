using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHtmlTemplate.Models;

namespace WebAppHtmlTemplate.Controllers
{
    public class DataTypeController : Controller
    {
        // GET: DataType
        public ActionResult Index()
        {
            DemoModel2 model = new DemoModel2
            {
                Foo1=123.0m,
                Bar1=3.14159m,
                Foo2=true,
                Foo3=123,
                Bar3=1200000,
                Baz3=(byte)1,
                Foor4=Color.Red,
                Foor5=new object(),
                Bar5="小明",
                Address=new Address
                {
                    Province="上海",
                    City="上海"
                }
            };
            return View(model);
        }
    }
}