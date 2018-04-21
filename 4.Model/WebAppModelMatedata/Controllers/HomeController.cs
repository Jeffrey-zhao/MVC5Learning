using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppModelMatedata.Customs;
using WebAppModelMatedata.Models;

namespace WebAppModelMatedata.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ModelMetadataInfo metadataInfo = new ModelMetadataInfo(typeof(DemoModel), metadata => metadata.TemplateHint);

            return View(metadataInfo);
        }

        public ActionResult Index2()
        {
            DemoModel2 model = new DemoModel2()
            {
                Foo = "Foo",
                Bar = "Bar",
                Baz = "Baz"
            };
            return View(model);
        }

        public ActionResult Index3()
        {
            ModelMetadataInfo metadataInfo = new ModelMetadataInfo(typeof(DemoModel3), 
                metadata => metadata.TemplateHint,
                metadata=>metadata.HideSurroundingHtml);

            return View(metadataInfo);
        }

        public ActionResult Index4()
        {
            ModelMetadataInfo metadataInfo = new ModelMetadataInfo(typeof(DemoModel4),
                metadata => metadata.DataTypeName);

            return View(metadataInfo);
        }

        public ActionResult Index5()
        {
            ModelMetadataInfo metadataInfo = new ModelMetadataInfo(typeof(DemoModel5),
                metadata => metadata.IsReadOnly);

            return View(metadataInfo);
        }

        public ActionResult Index6()
        {
            ModelMetadataInfo metadataInfo = new ModelMetadataInfo(typeof(DemoModel6),
                metadata => metadata.DisplayName,
                metadata => metadata.Description,
                metadata => metadata.ShortDisplayName,
                metadata => metadata.Watermark,
                metadata => metadata.Order);

            return View(metadataInfo);
        }
        //验证方式：?foo=<script></script>&bar=<script></script>
        public ActionResult Index7(DemoModel7 demoModel)
        {
            return View(demoModel);
        }

        public ActionResult Employee(Employee model)
        {
            return View(model);
        }

        public ActionResult Employee2(Employee2 model)
        {
            return View(model);
        }
    }
}