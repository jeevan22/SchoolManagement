using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Bussiness.ViewModel
{
   public class TeacherAllocationViewModel
    {

        public int ID { get; set; }
        public int ClassMasterID { get; set; }
        public string ClassName { get; set; }
        public int TeacherMasterID { get; set; }
        public string TeacherName { get; set; }
        public int StudentMasterID { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
    }
}
