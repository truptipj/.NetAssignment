using Restful_Api_Assignment.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_Api_Assignment.DAL
{
  public interface ICollegeDal
  {
    IEnumerable<CollegeEntity> GetAllCollege();
    CollegeEntity GetById(int Id);
    Task<CollegeEntity> AddCollege(CollegeEntity collegeObj);
    CollegeEntity UpdateCollege(CollegeEntity updateCollege, int id);
    CollegeEntity DeleteCollege(int id);
  }

  public class CollegeDal : ICollegeDal
  {
    private readonly ApplicationDbContext _context;

    public CollegeDal(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<CollegeEntity> AddCollege(CollegeEntity collegeObj)
    {
      var data = await _context.College.AddAsync(collegeObj);
      _context.SaveChanges();
      return data.Entity;
    }

    public CollegeEntity DeleteCollege(int id)
    {
      var result = _context.College.Where(a => a.Id == id).FirstOrDefault();
      if (result != null)
      {
        _context.College.Remove(result);
        _context.SaveChanges();
        return result;
      }
      return null;
    }

    public IEnumerable<CollegeEntity> GetAllCollege()
    {
      return _context.College.ToList();
    }

    public CollegeEntity GetById(int Id)
    {
      return _context.College.FirstOrDefault(i => i.Id == Id);
    }

    public CollegeEntity UpdateCollege(CollegeEntity updateCollege, int id)
    {
      var update = _context.College.Where(i => i.Id == id).ToList();
      foreach (var collegeData in update)
      {
        if (collegeData.Id == id)
        {
          collegeData.Name = updateCollege.Name;
          collegeData.University = updateCollege.University;
          collegeData.Address = updateCollege.Address;
          collegeData.District = updateCollege.District;
          var updateddata = _context.College.Update(collegeData);
          _context.SaveChanges();
          return updateddata.Entity;
        }
      }
      return updateCollege;
    }
  }
}
