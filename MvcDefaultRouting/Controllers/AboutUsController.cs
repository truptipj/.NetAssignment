using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDefaultRouting.Controllers
{
  public class AboutUsController : Controller
  {
    public IActionResult About()
    {
      return View();
    }
  }
}
