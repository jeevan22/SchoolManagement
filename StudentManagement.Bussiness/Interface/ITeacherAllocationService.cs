using SchoolManagement.Bussiness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Bussiness.Interface
{
    public interface ITeacherAllocationService
    {
        List<TeacherAllocationViewModel> GetTeacherAllocationList();
        List<TeacherAllocationViewModel> GetTeacherAllocationByID(int id);
        TeacherAllocationViewModel AddAndUpdateTeacherAllocation(TeacherAllocationViewModel vmModel);
        bool DeleteTeacherAllocation(int id);
    }
}
