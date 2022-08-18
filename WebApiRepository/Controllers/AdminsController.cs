using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRepository.IService;
using WebApiRepository.Models;

namespace WebApiRepository.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AdminsController : GenericController<Admin>
  {
    public AdminsController(IGenericService<Admin> genericService) : base(genericService)

    {

    }
  }
}
