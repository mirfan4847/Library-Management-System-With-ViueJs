using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using LibraryManagementSystem.ExceptionManager;

namespace LibraryManagementSystem.Repository
{
    public class DepartmentRepository
    {
        LibraryManagementSystemEntities _db = new LibraryManagementSystemEntities();

        public string AddDepartment(DepartmentViewModel model)
        {
            try
            {
                var department = new Department()
                {
                    Name = model.Name,
                    Active = true,
                    Createdby = model.Createdby,
                    CreatedDate = DateTime.Now
                };

                _db.Departments.Add(department);
                int saved = _db.SaveChanges();
                return saved > 0 ? "Department Saved" : "Not Saved";
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }


        }

        public List<DepartmentViewModel> GetAllDepartment()
        {
            try
            {
                var query = from departmennt in _db.Departments
                            where departmennt.Active == true
                            select new DepartmentViewModel()
                            {
                                Name = departmennt.Name,
                                DepartmentId = departmennt.DepartmentId,
                            };
                return query.ToList();
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        public static List<DepartmentViewModel> DepartmentList()
        {
            LibraryManagementSystemEntities _db = new LibraryManagementSystemEntities();
            try
            {
                return (from dep in _db.Departments
                        where dep.Active == true
                        select new DepartmentViewModel()
                        {
                            DepartmentId = dep.DepartmentId,
                            Name = dep.Name
                        }).ToList();
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        public DepartmentViewModel Edit(int id)
        {
            try
            {
                DepartmentViewModel model = new DepartmentViewModel();
                var dept = _db.Departments.Where(x => x.DepartmentId == id).SingleOrDefault();
                if (dept != null)
                {
                    model.Name = dept.Name;
                    model.DepartmentId = dept.DepartmentId;
                    return model;
                }
                return null;
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        public string Update(DepartmentViewModel model)
        {
            try
            {
                var dept = _db.Departments.Where(x => x.DepartmentId == model.DepartmentId).SingleOrDefault();
                if (dept != null)
                {
                    dept.Name = model.Name;
                    dept.ModifyBy = model.ModifyBy;
                    dept.ModifyDate = model.ModifyDate;
                }
                int saved = _db.SaveChanges();
                return saved > 0 ? "Department Saved" : "Not Saved";
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }

        }

        public bool Deactive(int id)
        {
            try
            {
                var dept = _db.Departments.Where(x => x.DepartmentId == id).SingleOrDefault();
                if (dept != null)
                {
                    dept.Active = false;
                    dept.ModifyDate = DateTime.Now;
                    int saved = _db.SaveChanges();
                    return saved > 0 ? true : false;
                }
                return false;
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return false;
            }
        }

    }
}