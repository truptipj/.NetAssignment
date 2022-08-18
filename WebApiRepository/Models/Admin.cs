using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRepository.Models
{
  public class Admin
  {
    public int AdminId { get; set; }
    public string AdminFirstName { get; set; }
    public string AdminLastName { get; set; }
    public string AdminEmail { get; set; }
    public long AdminMobileNo { get; set; }
  }
}
