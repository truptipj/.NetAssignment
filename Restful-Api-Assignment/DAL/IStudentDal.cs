using Restful_Api_Assignment.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_Api_Assignment.DAL
{
  public interface IStudentDal
  {
    IEnumerable<StudentEntity> GetAllStudent();
    StudentEntity GetById(int Id);
    Task<StudentEntity> AddStudent(StudentEntity studentObj);
    StudentEntity UpdateStudent(StudentEntity updateStudent, int id);
    StudentEntity DeleteStudent(int id);
  }
  public class StudentDal : IStudentDal
  {
    private readonly ApplicationDbContext _context;

    public StudentDal(ApplicationDbContext context)
    {
      this._context = context;
    }

    public async Task<StudentEntity> AddStudent(StudentEntity studentObj)
    {
      var data = await _context.Student.AddAsync(studentObj);
      _context.SaveChanges();
      return data.Entity;
    }

    public StudentEntity DeleteStudent(int id)
    {
      var result = _context.Student.Where(i => i.Id == id).FirstOrDefault();
      if (result != null)
      {
        _context.Student.Remove(result);
        _context.SaveChanges();
        return result;
      }
      return null;
    }

    public IEnumerable<StudentEntity> GetAllStudent()
    {
      return _context.Student.ToList();
    }

    public StudentEntity GetById(int Id)
    {
      return _context.Student.FirstOrDefault(i => i.Id == Id);
    }

    public StudentEntity UpdateStudent(StudentEntity updateStudent, int id)
    {
      var update = _context.Student.Where(a => a.Id == id).ToList();
      foreach (var data in update)
      {
        if (data.Id == id)
        {
          data.FirstName = updateStudent.FirstName;
          data.LastName = updateStudent.LastName;
          data.Email = updateStudent.Email;
          data.Phone = updateStudent.Phone;
          data.DateOfBirth = updateStudent.DateOfBirth;
          data.CollegeId = updateStudent.CollegeId;

          var updatedData = _context.Student.Update(data);
          _context.SaveChanges();
          return updatedData.Entity;
        }
      }
      return updateStudent;
    }
  }
}
