using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppModelValidation.Models;

namespace WebAppModelValidation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult Index(Person person)
        {
            //Validate(person);
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            else
            {
                return Content("输入数据通过验证");
            }
        }

        // GET: Home
        public ActionResult Index2()
        {
            return View(new Models.Validatable.Person());
        }

        [HttpPost]
        public ActionResult Index2(Models.Validatable.Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            else
            {
                return Content("输入数据通过验证");
            }
        }

        // GET: Home
        public ActionResult Index3()
        {
            return View(new Models.DataError.Person());
        }

        [HttpPost]
        public ActionResult Index3(Models.DataError.Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            else
            {
                return Content("输入数据通过验证");
            }
        }
        private void Validate(Person person)
        {
            if (string.IsNullOrEmpty(person.Name))
            {
                ModelState.AddModelError("Name", "Name 是必须字段");
            }
            if (string.IsNullOrEmpty(person.Gender))
            {
                ModelState.AddModelError("Gender", "Gender 是必须字段");
            }
            else if (!new string[] { "M", "F" }.Any(g => string.Compare(person.Gender, g, true) == 0))
            {
                ModelState.AddModelError("Gender", "有效Gender 必须是M，F之一");
            }
            if (null == person.Age)
            {
                ModelState.AddModelError("Age", "Age 是必须字段");
            }
            else if (person.Age > 25 || person.Age < 18)
            {
                ModelState.AddModelError("Age", "有效Age 必须在18到25岁之间");
            }
        }
    }
}