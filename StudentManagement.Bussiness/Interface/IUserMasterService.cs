using SchoolManagement.Bussiness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Bussiness.Interface
{
    public interface IUserMasterService
    {
        bool LoginUser(UserMasterViewModel vmModel);
    }
}
