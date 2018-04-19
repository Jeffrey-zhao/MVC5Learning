using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppDependencyResolver.Services;

namespace WebAppDependencyResolver.Controllers
{
    public class HomeController : Controller
    {
        public IEmployeeRepository Respository { get; private set; }
        public HomeController(IEmployeeRepository repo)
        {
            this.Respository = repo;
        }
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
    }
}