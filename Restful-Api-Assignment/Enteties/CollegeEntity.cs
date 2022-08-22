using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_Api_Assignment.Enteties
{
  public class CollegeEntity
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string University { get; set; }

    [Required]
    [MaxLength(50)]
    public string Address { get; set; }

    [Required]
    [MaxLength(50)]
    public string District { get; set; }
  }
}
