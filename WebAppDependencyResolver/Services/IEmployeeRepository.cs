using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppDependencyResolver.Models;

namespace WebAppDependencyResolver.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(string id = "");
    }
}
