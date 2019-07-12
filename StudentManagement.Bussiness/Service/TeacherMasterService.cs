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
    public class TeacherMasterService : ITeacherMasterService
    {
        SchoolManagementEntities _db = new SchoolManagementEntities();
        public List<TeacherMasterViewModel> GetTeacherMasterList()
        {
            var list = new List<TeacherMasterViewModel>();
            try
            {
                list = (from a in _db.TeacherMasters
                        select new TeacherMasterViewModel
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
        public List<TeacherMasterViewModel> GetTeacherMasterByID(int id)
        {
            var record = new List<TeacherMasterViewModel>();
            try
            {
                record = (from a in _db.TeacherMasters
                          where a.ID == id
                          select new TeacherMasterViewModel
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
        public TeacherMasterViewModel AddAndUpdateTeacherMaster(TeacherMasterViewModel vmModel)
        {
            try
            {
                if (vmModel.ID > 0)
                {
                    var record = _db.TeacherMasters.OrderByDescending(x => x.ID).Where(x => x.ID == vmModel.ID).FirstOrDefault();
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
                    TeacherMaster _TeacherMaster = new TeacherMaster();
                    _TeacherMaster.Name = vmModel.Name;
                    _TeacherMaster.FatherName = vmModel.FatherName;
                    _TeacherMaster.Address = vmModel.Address;
                    _TeacherMaster.PhoneNo = vmModel.PhoneNo;
                    _TeacherMaster.Email = vmModel.Email;
                    _TeacherMaster.DOB = vmModel.DOB;
                    _TeacherMaster.Gender = vmModel.Gender;
                    _db.TeacherMasters.Add(_TeacherMaster);
                    _db.SaveChanges();
                    vmModel.ID = _TeacherMaster.ID;
                }
            }
            catch (Exception ex)
            {

            }
            return vmModel;
        }
        public bool DeleteTeacherMaster(int id)
        {
            bool isDeleted = false;
            try
            {
                var record = _db.TeacherMasters.OrderByDescending(x => x.ID).Where(x => x.ID == id).FirstOrDefault();
                _db.TeacherMasters.Remove(record);
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
