using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppController.Models;

namespace WebAppController.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(string id = "");
    }
}
