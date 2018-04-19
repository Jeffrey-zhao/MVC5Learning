using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Attributes;
using WebAppController.Services;

namespace WebAppController.Controllers
{
    public class HomeController : Controller
    {
        [Dependency]
        public IEmployeeRepository Respository { get; set; }
        public ActionResult GetAllEmployees()
        {
            var employees = this.Respository.GetEmployees();
            return View(employees);
        }

        public ActionResult GetEmployee(string id)
        {
            var employee = this.Respository.GetEmployees(id).FirstOrDefault();
            if (employee != null)
            {
                return View(employee);
            }
            throw new HttpException(404, $"ID:{id} not exists");
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}