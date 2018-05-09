using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppView.Controllers
{
    public class FileResultController : Controller
    {
        // GET: FileResult
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Image(string id)
        {
            string path = Server.MapPath("/images/" + id + ".jpg");
            return File(path, "image/jpeg");
        }

        public ActionResult JavaScript()
        {
            return JavaScript("alert('Hello World!');");
        }

        public ActionResult OtherJavaScript()
        {
            return Content("alert('Hello World,again!');", "application/x-javascript");
        }
    }
}