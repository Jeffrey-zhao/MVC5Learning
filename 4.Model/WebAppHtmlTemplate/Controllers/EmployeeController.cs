using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppHtmlTemplate.Models;

namespace WebAppHtmlTemplate.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            Employee employee = new Employee
            {
                Name="张三",
                Gender="M",
                Education="M",
                Departments=new string[] {"Dev1","Dev2"},
                Skills=new string[] {"CSharp","AdoNet","EF"}
            };
            return View(employee);
        }
    }
}