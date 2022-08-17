using Microsoft.EntityFrameworkCore;
using SimpleRepositoryCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRepositoryCrud
{
  public class EmployeeContext : DbContext
  {
    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }
    public DbSet<Employee> Employee { get; set; }

  }
}
