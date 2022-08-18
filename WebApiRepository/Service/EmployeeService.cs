using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRepository.Models;
using WebApiRepository.Service;

namespace WebApiRepository.Service
{
  public class EmployeeService : IService.IGenericService<Employee>
  {
    List<Employee> _Employees = new List<Employee>();

    public EmployeeService()
    {
      for (int i = 1; i <= 9; i++)
      {
        _Employees.Add(new Employee()
        {
          EmployeeId = i,
          FirstName = "empFirstName" + i,
          LastName = "empLastName" + i,
          Email = "emp@gmail.com" + i,
          MobileNo = 9123456787 + i
        });
      }
    }
    public List<Employee> Delete(int id)
    {
      _Employees.RemoveAll(x => x.EmployeeId == id);
      return _Employees;
    }

    public List<Employee> GetAll()
    {
      return _Employees;
    }

    public Employee GetById(int id)
    {
      return _Employees.Where(x => x.EmployeeId == id).SingleOrDefault();
    }

    public List<Employee> Insert(Employee item)
    {
      _Employees.Add(item);
      return _Employees;
    }
  }
}
