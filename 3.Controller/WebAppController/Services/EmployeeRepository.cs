using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppController.Models;

namespace WebAppController.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> employees;
        static EmployeeRepository()
        {
            employees = new List<Employee>();
            employees.Add(new Employee { Id = "1", Name = "zhao" });
            employees.Add(new Employee { Id = "2", Name = "jeffrey" });
            employees.Add(new Employee { Id = "3", Name = "lily" });
        }
        public IEnumerable<Employee> GetEmployees(string id = "")
        {
            return employees.Where(e => e.Id == id || string.IsNullOrEmpty(id));

        }
    }
}
