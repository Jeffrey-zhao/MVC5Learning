using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHtmlTemplate.Models;

namespace WebAppHtmlTemplate.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Employee model = new Employee
            {
                Name = "jeffrey",
                Department = "dev",
                IsPartTime=true
            };
            return View(model);
        }
    }
}