using SimpleRepositoryCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRepositoryCrud.Repository
{
  public interface EmployeeRepo 
  {
     Task<IEnumerable<Employee>> GetEmployees();
    Task<Employee> GetEmployee(int id);
    Task<Employee> AddEmployee(Employee employee);
    Task<Employee> UpdateEmployee(Employee employee);
    void DeleteEmployee(int id);

  }
}
