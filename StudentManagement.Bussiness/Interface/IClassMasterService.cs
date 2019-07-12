using SchoolManagement.Bussiness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Bussiness.Interface
{
    public interface IClassMasterService
    {
        List<ClassMasterViewModel> GetClassMasterList();
        List<ClassMasterViewModel> GetClassMasterByID(int id);
        ClassMasterViewModel AddAndUpdateClassMaster(ClassMasterViewModel vmModel);
        bool DeleteClassMaster(int id);
    }
}
