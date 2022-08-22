using Restful_Api_Assignment.DAL;
using Restful_Api_Assignment.Enteties;
using Restful_Api_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful_Api_Assignment.Services
{
  public interface IStudentService
  {
    IEnumerable<StudentModel> GetAllStudent();
    StudentModel GetById(int Id);
    Task<StudentModel> AddStudent(StudentModel studentObj);
    StudentModel UpdateStudent(StudentModel updateStudent, int id);
    StudentModel DeleteStudent(int id);

  }
  public class StudentService : IStudentService
  {
    private readonly IStudentDal StudentDal;
    public StudentService(IStudentDal StudentDal)
    {
      this.StudentDal = StudentDal;
    }

    public async Task<StudentModel> AddStudent(StudentModel studentObj)
    {
      var obj = new StudentEntity
      {
        FirstName = studentObj.FirstName,
        LastName = studentObj.LastName,
        Email = studentObj.Email,
        Phone = studentObj.Phone,
        DateOfBirth = studentObj.DateOfBirth,
        CollegeId = studentObj.CollegeId

      };

      var result = await StudentDal.AddStudent(obj);
      return new StudentModel
      {
        Id = result.Id,
        FirstName = studentObj.FirstName,
        LastName = studentObj.LastName,
        Email = studentObj.Email,
        Phone = studentObj.Phone,
        DateOfBirth = studentObj.DateOfBirth,
        CollegeId = studentObj.CollegeId
      };

    }

    public StudentModel DeleteStudent(int id)
    {
      var deleteStudent = StudentDal.DeleteStudent(id);
      return new StudentModel
      {
        Id = deleteStudent.Id,
        FirstName = deleteStudent.FirstName,
        LastName = deleteStudent.LastName,
        Email = deleteStudent.Email,
        Phone = deleteStudent.Phone,
        DateOfBirth = deleteStudent.DateOfBirth,
        CollegeId = deleteStudent.CollegeId
      };
    }

    public IEnumerable<StudentModel> GetAllStudent()
    {
      var students = StudentDal.GetAllStudent();
      return (from student in students
              select new StudentModel
              {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Phone = student.Phone,
                DateOfBirth = student.DateOfBirth,
                CollegeId = student.CollegeId
              }).ToList();
    }

    public StudentModel GetById(int Id)
    {
      var studentData = StudentDal.GetById(Id);
      if (studentData != null)
      {
        return new StudentModel
        {
          Id = studentData.Id,
          FirstName = studentData.FirstName,
          LastName = studentData.LastName,
          Email = studentData.Email,
          Phone = studentData.Phone,
          DateOfBirth = studentData.DateOfBirth,
          CollegeId = studentData.CollegeId
        };
      }
      else
      {
        return null;
      }
    }

    public StudentModel UpdateStudent(StudentModel updateStudent, int id)
    {
      var obj = new StudentEntity
      {
        Id = updateStudent.Id,
        FirstName = updateStudent.FirstName,
        LastName = updateStudent.LastName,
        Email = updateStudent.Email,
        Phone = updateStudent.Phone,
        DateOfBirth = updateStudent.DateOfBirth,
        CollegeId = updateStudent.CollegeId

      };
      var updateData = StudentDal.UpdateStudent(obj, id);
      return new StudentModel
      {
        Id = updateData.Id,
        FirstName = updateData.FirstName,
        LastName = updateStudent.LastName,
        Email = updateStudent.Email,
        Phone = updateStudent.Phone,
        DateOfBirth = updateStudent.DateOfBirth,
        CollegeId = updateStudent.CollegeId
      };

    }
  }
}
