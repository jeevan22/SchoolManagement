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
    public class StudentMasterService: IStudentMasterService
    {
        SchoolManagementEntities _db = new SchoolManagementEntities();
        public List<StudentMasterViewModel> GetStudentMasterList()
        {
            var list = new List<StudentMasterViewModel>();
            try
            {
                list = (from a in _db.StudentMasters
                        select new StudentMasterViewModel
                        {
                            ID = a.ID,
                            Name = a.Name,
                            FatherName = a.FatherName,
                            Address = a.Address,
                            PhoneNo = a.PhoneNo,
                            Email = a.Email,
                            DOB = a.DOB,
                            Gender = a.Gender
                        }).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
        public List<StudentMasterViewModel> GetStudentMasterByID(int id)
        {
            var record = new List<StudentMasterViewModel>();
            try
            {
                record = (from a in _db.StudentMasters
                          where a.ID == id
                          select new StudentMasterViewModel
                          {
                              ID = a.ID,
                              Name = a.Name,
                              FatherName = a.FatherName,
                              Address = a.Address,
                              PhoneNo = a.PhoneNo,
                              Email = a.Email,
                              DOB = a.DOB,
                              Gender = a.Gender
                          }).ToList();
            }
            catch (Exception ex)
            {

            }
            return record;
        }
        public StudentMasterViewModel AddAndUpdateStudentMaster(StudentMasterViewModel vmModel)
        {
            try
            {
                if (vmModel.ID > 0)
                {
                    var record = _db.StudentMasters.OrderByDescending(x => x.ID).Where(x => x.ID == vmModel.ID).FirstOrDefault();
                    record.Name = vmModel.Name;
                    record.FatherName = vmModel.FatherName;
                    record.Address = vmModel.Address;
                    record.PhoneNo = vmModel.PhoneNo;
                    record.Email = vmModel.Email;
                    record.DOB = vmModel.DOB;
                    record.Gender = vmModel.Gender;
                    _db.SaveChanges();

                }
                else
                {
                    StudentMaster _StudentMaster = new StudentMaster();
                    _StudentMaster.Name = vmModel.Name;
                    _StudentMaster.FatherName = vmModel.FatherName;
                    _StudentMaster.Address = vmModel.Address;
                    _StudentMaster.PhoneNo = vmModel.PhoneNo;
                    _StudentMaster.Email = vmModel.Email;
                    _StudentMaster.DOB = vmModel.DOB;
                    _StudentMaster.Gender = vmModel.Gender;
                    _db.StudentMasters.Add(_StudentMaster);
                    _db.SaveChanges();
                    vmModel.ID = _StudentMaster.ID;
                }
            }
            catch (Exception ex)
            {

            }
            return vmModel;
        }
        public bool DeleteStudentMaster(int id)
        {
            bool isDeleted = false;
            try
            {
                var record = _db.StudentMasters.OrderByDescending(x => x.ID).Where(x => x.ID == id).FirstOrDefault();
                _db.StudentMasters.Remove(record);
                _db.SaveChanges();
                isDeleted = true;
            }
            catch (Exception ex)
            {

            }
            return isDeleted;
        }
    }
}
