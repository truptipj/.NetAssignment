using Restful_Api_Assignment.DAL;
using Restful_Api_Assignment.Enteties;
using Restful_Api_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_Api_Assignment.Services
{
  public interface ICollegeService
  {
    IEnumerable<CollegeModel> GetAllCollege();
    CollegeModel GetById(int Id);
    Task<CollegeModel> AddCollege(CollegeModel collegeObj);
    CollegeModel UpdateCollege(CollegeModel updateCollege, int id);
    CollegeModel DeleteCollege(int id);

  }
  public class CollegeService : ICollegeService
  {
    private readonly ICollegeDal CollegeDal;
    public CollegeService(ICollegeDal CollegeDal)
    {
      this.CollegeDal = CollegeDal;
    }

    public async Task<CollegeModel> AddCollege(CollegeModel collegeObj)
    {
      var obj = new CollegeEntity
      {
        Name = collegeObj.Name,
        University = collegeObj.University,
        Address = collegeObj.Address,
        District = collegeObj.District,

      };

      var result = await CollegeDal.AddCollege(obj);
      return new CollegeModel
      {
        Id = result.Id,
        Name = result.Name,
        University = result.University,
        Address = result.Address,
        District = result.District,
      };

    }

    public CollegeModel DeleteCollege(int id)
    {
      var deleteData = CollegeDal.DeleteCollege(id);
      return new CollegeModel
      {
        Id = deleteData.Id,
        Name = deleteData.Name,
        University = deleteData.University,
        Address = deleteData.Address,
        District = deleteData.District
      };
    }

    public IEnumerable<CollegeModel> GetAllCollege()
    {
      var college = CollegeDal.GetAllCollege();
      return (from colleges in college
              select new CollegeModel
              {
                Id = colleges.Id,
                Name = colleges.Name,
                University = colleges.University,
                Address = colleges.Address,
                District = colleges.District
              }).ToList();
    }

    public CollegeModel GetById(int Id)
    {
      var collegeData = CollegeDal.GetById(Id);
      if (collegeData != null)
      {
        return new CollegeModel
        {
          Id = collegeData.Id,
          Name = collegeData.Name,
          University = collegeData.University,
          Address = collegeData.Address,
          District = collegeData.District
        };
      }
      else
      {
        return null;
      }
    }

    public CollegeModel UpdateCollege(CollegeModel updateCollege, int id)
    {
      var obj = new CollegeEntity
      {
        Id = updateCollege.Id,
        Name = updateCollege.Name,
        University = updateCollege.University,
        Address = updateCollege.Address,
        District = updateCollege.District

      };
      var updatedata = CollegeDal.UpdateCollege(obj, id);
      return new CollegeModel
      {
        Id = updatedata.Id,
        Name = updateCollege.Name,
        University = updateCollege.University,
        Address = updateCollege.Address,
        District = updateCollege.District
      };

    }
  }
}
