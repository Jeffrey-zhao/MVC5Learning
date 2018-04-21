using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppModelMetadataDetail.Customs;
using WebAppModelMetadataDetail.Models;

namespace WebAppModelMetadataDetail.Controllers
{
    public class TestController : Controller
    {
        delegate string Test(string str);
        public string TT()
        {
            return "";
        }
        // GET: Test
        public ActionResult Index()
        {
            TestCachedModelMetadata<TestModelMetadata> model = new TestCachedModelMetadata<TestModelMetadata>();
            var type=model.DataTypeName;
            Func<string> xx = new Func<string>(TT);
            return View(model);
        }
    }
}