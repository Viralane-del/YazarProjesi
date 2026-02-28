using BusinessLayer.Abstract;
using BusinessLayer.Security;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDAL _adminDAL;
        public AdminManager(IAdminDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }

        public void AdminAdd(Admin admin)
        {
             _adminDAL.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDAL.Update(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDAL.Update(admin);
        }

        public Admin GetByID(int id)
        {
            return _adminDAL.Get(x => x.AdminID == id);
        }

        public Admin GetByUserName(string username)
        {
            return _adminDAL.Get(x => x.AdminUserName == username);
        }

        public List<Admin> GetList()
        {
            return _adminDAL.List();
        }

        public bool Login(string username, string password)
        {
            var admin = _adminDAL.Get(x => x.AdminUserName.ToLower() == username.ToLower());
            if (admin == null)
                return false;

            string hashedPassword = HashHelper.ComputeSha256Hash(password.Trim());
            return admin.AdminPassword == hashedPassword;
        }

    }
}
