using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHtmlTemplate.Models;

namespace WebAppHtmlTemplate.Controllers
{
    public class PointController : Controller
    {
        // GET: Point
        public ActionResult Index()
        {
            Trangle model = new Trangle
            {
                A = new Point(1, 2),
                B = new Point(2, 3),
                C = new Point(3, 4)
            };
            return View(model);
        }
    }
}