using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleRepositoryCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRepositoryCrud.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeeController : ControllerBase
  {
    private readonly EmployeeContext _employeeContext;

    public EmployeeController(EmployeeContext employeeContext)
    {
      _employeeContext = employeeContext;
    }

    [HttpGet]
    public IEnumerable<Employee> GetEmployee()
    {
      return _employeeContext.Employee;
    }




    [HttpPost]
    public void Post([FromBody] Employee employee)
    {
      _employeeContext.Employee.Add(employee);
      _employeeContext.SaveChanges();
    }



    [HttpPut("{Id}")]
    public void Put(int Id, [FromBody] Employee employee)
    {
      employee.Id = Id;
      _employeeContext.Employee.Update(employee);
      _employeeContext.SaveChanges();
    }


    [HttpDelete]
    public void Delete(int Id)
    {
      var emp = _employeeContext.Employee.FirstOrDefault(x => x.Id == Id);
      if (emp != null)
        {
      _employeeContext.Employee.Remove(emp);
       _employeeContext.SaveChanges();
      }
    }

  }
}
