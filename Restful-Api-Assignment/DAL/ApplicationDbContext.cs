using Microsoft.EntityFrameworkCore;
using Restful_Api_Assignment.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_Api_Assignment.DAL
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions options)
           : base(options)
    {
    }
    public DbSet<CollegeEntity> College { get; set; }
    public DbSet<StudentEntity> Student { get; set; }
  }
}
