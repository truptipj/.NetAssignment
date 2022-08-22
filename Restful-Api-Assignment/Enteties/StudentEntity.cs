using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_Api_Assignment.Enteties
{
  public class StudentEntity
  {
    public int Id { get; set; }
    [Required, MaxLength(30)]
    public string FirstName { get; set; }
    [Required, MaxLength(30)]
    public string LastName { get; set; }

    [Required, MaxLength(30), EmailAddress]
    public string Email { get; set; }

    [Required, MaxLength(30), Phone]
    public string Phone { get; set; }

    [Required(ErrorMessage = "DateOfBirth is required")]
    public DateTime DateOfBirth { get; set; }
    [Required]
    public int CollegeId { get; set; }
  }
}

