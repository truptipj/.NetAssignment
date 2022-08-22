using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restful_Api_Assignment.Models;
using Restful_Api_Assignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_Api_Assignment.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StudentController : ControllerBase
  {
    private readonly IStudentService studentService;
    public StudentController(IStudentService studentService)
    {
      this.studentService = studentService;
    }

    [HttpGet]
    public IActionResult GetAllStudent()
    {
      return Ok(studentService.GetAllStudent());
    }

    [HttpGet("{Id}")]
    public IActionResult GetById(int Id)
    {
      return Ok(studentService.GetById(Id));
    }

    [HttpPost]
    public IActionResult AddStudent(StudentModel studentObj)
    {
      return Ok(studentService.AddStudent(studentObj));
    }

    [HttpPut]
    public IActionResult UpdateStudent(StudentModel updateStudent, int id)
    {
      return Ok(studentService.UpdateStudent(updateStudent, id));
    }

    [HttpDelete]
    public IActionResult DeleteStudent(int id)
    {
      return Ok(studentService.DeleteStudent(id));
    }

  }
}
