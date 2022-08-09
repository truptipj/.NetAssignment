using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAttributeRouting
{
  public class BooksClass
  {
    public int AuthorId { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public int AuthorAge { get; set; }
    public string AuthorCity { get; set; } = string.Empty;
  }
}
