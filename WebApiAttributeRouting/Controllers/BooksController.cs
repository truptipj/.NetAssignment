using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAttributeRouting.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    
 
      private static List<BooksClass> Books = new List<BooksClass>()
      {
        
    new BooksClass()
        {
          AuthorId=101,
          AuthorName="Shivaji Savant",
          AuthorAge=35,
          AuthorCity="Pune"
        },

        new BooksClass()
        {
          AuthorId=102,
          AuthorName="Tanaji Savant",
          AuthorAge=25,
          AuthorCity="Satara"
        }
      };
    [HttpGet]
    [Route("GetBooksClass")]
    public ActionResult <BooksClass> GetBook()
    {
      return Ok(Books);
    }

    [HttpGet]
    [Route("GetBooksById")]
    public ActionResult <BooksClass> GetBook(int id)
    {
      var Book = Books.Find(x => x.AuthorId == id);
      if (Book == null)
        return BadRequest("No Book Found");

      return Ok(Book);
    }

    [HttpPost]
    [Route("AddBooks")]
    public ActionResult<BooksClass> AddBook(BooksClass request)
    {
      Books.Add(request);
         return Ok(Books);
    }

    [HttpPut]
    [Route("UpdateBooks")]
    public ActionResult<BooksClass> UpdateBook(BooksClass request)
    {
      var Book = Books.Find(x => x.AuthorId == request.AuthorId);
      if (Book == null)
        return BadRequest("No Book Found");
      Book.AuthorName = request.AuthorName;
      Book.AuthorAge = request.AuthorAge;
      Book.AuthorCity = request.AuthorCity;
      return Ok(Books);
    }

    [HttpDelete]
    [Route("DeleteBooks")]
    public ActionResult<BooksClass> DeleteBook(int id)
    {
      var Book = Books.Find(x => x.AuthorId == id);
      if (Book == null)
        return BadRequest("No Book Found");

      Books.Remove(Book);
      return Ok(Book);
    }
  }
}

