using SchoolManagement.Bussiness.Interface;
using SchoolManagement.Bussiness.ViewModel;
using SchoolManagement.Data;
using SchoolManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Bussiness.Service
{
    public class TeacherAllocationService : ITeacherAllocationService
    {
        SchoolManagementEntities _db = new SchoolManagementEntities();
        public List<TeacherAllocationViewModel> GetTeacherAllocationList()
        {
            var list = new List<TeacherAllocationViewModel>();
            try
            {
                list = (from a in _db.TeacherAllocations
                        join b in _db.ClassMasters on a.ClassMasterID equals b.ID
                        join c in _db.TeacherMasters on a.TeacherMasterID equals c.ID
                        join d in _db.StudentMasters on a.StudentMasterID equals d.ID
                        select new TeacherAllocationViewModel
                        {
                            ID = a.ID,
                            ClassName = b.ClassName,
                            TeacherName = c.Name,
                            StudentName = d.Name,
                            FatherName = d.FatherName
                        }).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
        public List<TeacherAllocationViewModel> GetTeacherAllocationByID(int id)
        {
            var record = new List<TeacherAllocationViewModel>();
            try
            {
                record = (from a in _db.TeacherAllocations
                          where a.ID == id
                          select new TeacherAllocationViewModel
                          {
                              ID = a.ID,
                              ClassMasterID = a.ClassMasterID,
                              TeacherMasterID = a.TeacherMasterID,
                              StudentMasterID = a.StudentMasterID
                          }).ToList();
            }
            catch (Exception ex)
            {

            }
            return record;
        }
        public TeacherAllocationViewModel AddAndUpdateTeacherAllocation(TeacherAllocationViewModel vmModel)
        {
            try
            {
                if (vmModel.ID > 0)
                {
                    var record = _db.TeacherAllocations.OrderByDescending(x => x.ID).Where(x => x.ID == vmModel.ID).FirstOrDefault();
                    record.ClassMasterID = vmModel.ClassMasterID;
                    record.TeacherMasterID = vmModel.TeacherMasterID;
                    record.StudentMasterID = vmModel.StudentMasterID;
                    _db.SaveChanges();

                }
                else
                {
                    TeacherAllocation _TeacherAllocation = new TeacherAllocation();
                    _TeacherAllocation.ClassMasterID = vmModel.ClassMasterID;
                    _TeacherAllocation.TeacherMasterID = vmModel.TeacherMasterID;
                    _TeacherAllocation.StudentMasterID = vmModel.StudentMasterID;
                    _db.TeacherAllocations.Add(_TeacherAllocation);
                    _db.SaveChanges();
                    vmModel.ID = _TeacherAllocation.ID;
                }
            }
            catch (Exception ex)
            {

            }
            return vmModel;
        }
        public bool DeleteTeacherAllocation(int id)
        {
            bool isDeleted = false;
            try
            {
                var record = _db.TeacherAllocations.OrderByDescending(x => x.ID).Where(x => x.ID == id).FirstOrDefault();
                _db.TeacherAllocations.Remove(record);
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
