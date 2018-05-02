using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebAppFilter.Customs;

namespace WebAppFilter.Controllers
{
    [Authenticate]
    public class HomeController : Controller
    {
        // GET: Home
        public void Index()
        {
            Response.Write($"Controller.User:{this.User.Identity.Name}<br/>");
            Response.Write($"HttpContext.User:{this.ControllerContext.HttpContext.User.Identity.Name}<br/>");
            Response.Write($"Thread.CurrentPrincipal.User:{Thread.CurrentPrincipal.Identity.Name}<br/>");
            //return View();
        }
    }
}