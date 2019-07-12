using SchoolManagement.Bussiness.Interface;
using SchoolManagement.Bussiness.ViewModel;
using SchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Bussiness.Service
{
    public class UserMasterService : IUserMasterService
    {
        SchoolManagementEntities _db = new SchoolManagementEntities();
        public bool LoginUser(UserMasterViewModel vmModel)
        {
            bool isLogin = false;
            try
            {
                var record = (from a in _db.Users
                              where a.Name == vmModel.Name && a.Password == vmModel.Password
                              select a).Count() > 0 ? true : false;
                if (record)
                {
                    isLogin = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isLogin;
        }
    }
}
