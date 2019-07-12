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
    public class ClassMasterService : IClassMasterService
    {
        SchoolManagementEntities _db = new SchoolManagementEntities();
        public List<ClassMasterViewModel> GetClassMasterList()
        {
            var list = new List<ClassMasterViewModel>();
            try
            {
                list = (from a in _db.ClassMasters
                        select new ClassMasterViewModel
                        {
                            ID = a.ID,
                            ClassName = a.ClassName
                        }).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
        public List<ClassMasterViewModel> GetClassMasterByID(int id)
        {
            var record = new List<ClassMasterViewModel>();
            try
            {
                record = (from a in _db.ClassMasters
                          where a.ID == id
                          select new ClassMasterViewModel
                          {
                              ID = a.ID,
                              ClassName = a.ClassName
                          }).ToList();
            }
            catch (Exception ex)
            {

            }
            return record;
        }
        public ClassMasterViewModel AddAndUpdateClassMaster(ClassMasterViewModel vmModel)
        {
            try
            {
                if (vmModel.ID > 0)
                {
                    var record = _db.ClassMasters.OrderByDescending(x => x.ID).Where(x => x.ID == vmModel.ID).FirstOrDefault();
                    record.ClassName = vmModel.ClassName;
                    _db.SaveChanges();

                }
                else
                {
                    ClassMaster _classMaster = new ClassMaster();
                    _classMaster.ClassName = vmModel.ClassName;
                    _db.ClassMasters.Add(_classMaster);
                    _db.SaveChanges();
                    vmModel.ID = _classMaster.ID;
                }
            }
            catch (Exception ex)
            {

            }
            return vmModel;
        }
        public bool DeleteClassMaster(int id)
        {
            bool isDeleted = false;
            try
            {
                var record = _db.ClassMasters.OrderByDescending(x => x.ID).Where(x => x.ID == id).FirstOrDefault();
                _db.ClassMasters.Remove(record);
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
