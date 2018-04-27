using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppParameterValidate.Models;

namespace WebAppParameterValidate.Controllers
{
    public class ClientValidatorController : Controller
    {
        // GET: ClientValidator
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DemoModel model)
        {
            return View(model);
        }
    }
}