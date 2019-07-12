using SchoolManagement.Bussiness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Bussiness.Interface
{
    public interface IStudentMasterService
    {
        List<StudentMasterViewModel> GetStudentMasterList();
        List<StudentMasterViewModel> GetStudentMasterByID(int id);
        StudentMasterViewModel AddAndUpdateStudentMaster(StudentMasterViewModel vmModel);
        bool DeleteStudentMaster(int id);
    }
}
