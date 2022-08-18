using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRepository.Models;

namespace WebApiRepository.Service
{
  public class AdminService : IService.IGenericService<Admin>
  {
    List<Admin> _Admins = new List<Admin>();

    public AdminService()
    {
      for (int i = 1; i <= 9; i++)
      {
        _Admins.Add(new Admin()
        {
          AdminId = i,
          AdminFirstName = "adminFirstName" + i,
          AdminLastName = "adminLastName" + i,
          AdminEmail = "admin@gmail.com" + i,
          AdminMobileNo = 8446785643 + i
        });
      }
    }
    public List<Admin> Delete(int id)
    {
      _Admins.RemoveAll(x => x.AdminId == id);
      return _Admins;
    }

    public List<Admin> GetAll()
    {
      return _Admins;
    }

    public Admin GetById(int id)
    {
      return _Admins.Where(x => x.AdminId == id).SingleOrDefault();
    }

    public List<Admin> Insert(Admin item)
    {
      _Admins.Add(item);
      return _Admins;
    }
  }
}
