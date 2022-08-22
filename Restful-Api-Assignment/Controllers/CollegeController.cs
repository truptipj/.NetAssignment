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
  public class CollegeController : ControllerBase
  {
    private readonly ICollegeService _collegeService;

    public CollegeController(ICollegeService collegeService)
    {
      _collegeService = collegeService;
    }
    [HttpGet]
    public IActionResult GetAllCollege()
    {
      return Ok(_collegeService.GetAllCollege());
    }

    [HttpGet("{Id}")]
    public IActionResult GetById(int Id)
    {
      return Ok(_collegeService.GetById(Id));
    }

    [HttpPost]
    public IActionResult AddCollege(CollegeModel collegeobj)
    {
      return Ok(_collegeService.AddCollege(collegeobj));
    }

    [HttpPut]
    public IActionResult UpdateCollege(CollegeModel updateCollege, int id)
    {
      return Ok(_collegeService.UpdateCollege(updateCollege, id));
    }

    [HttpDelete]
    public IActionResult DeleteCollege(int id)
    {
      return Ok(_collegeService.DeleteCollege(id));

    }

  }
}
