using SchoolManagement.Bussiness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SchoolManagement.Bussiness.Interface
{
    public interface ITeacherMasterService
    {
        List<TeacherMasterViewModel> GetTeacherMasterList();
        List<TeacherMasterViewModel> GetTeacherMasterByID(int id);
        TeacherMasterViewModel AddAndUpdateTeacherMaster(TeacherMasterViewModel vmModel);
        bool DeleteTeacherMaster(int id);
    }
}
