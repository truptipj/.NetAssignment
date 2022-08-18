using Microsoft.EntityFrameworkCore;
using SimpleRepositoryCrud.Models;
using SimpleRepositoryCrud.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRepositoryCrud.Service
{
    public class EmployeeService : EmployeeRepo
    {
        internal readonly IEnumerable<Employee> Employee;
        private readonly EmployeeContext _employeeContext;
       // private readonly DbSet<Employee> Employee;

        public EmployeeService()
        {
            _employeeContext = new EmployeeContext();
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            await _employeeContext.Employee.AddAsync(employee);
            _employeeContext.SaveChanges();
            return employee;
            //var data = await _employeeContext.E.AddAsync(employee);
            //_employeeContext.SaveChanges();
            //return data.Entity;
        }

        public async void DeleteEmployee(int id)
        {
            var emp = await _employeeContext.Employee.Where(x => x.Id == id).FirstOrDefaultAsync();
               if (emp != null)
                {
                   _employeeContext.Employee.Remove(emp);
                   await _employeeContext.SaveChangesAsync();
              }
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _employeeContext.Employee.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeContext.Employee.ToListAsync();
        }

        public Task<Employee> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
        

    }
}
