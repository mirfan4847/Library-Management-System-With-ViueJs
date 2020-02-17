using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LibraryManagementSystem.ViewModel;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.ExceptionManager;
using System.Web.Mvc;

namespace LibraryManagementSystem.Repository
{
    public class CategoryRepository
    {
        LibraryManagementSystemEntities _db = new LibraryManagementSystemEntities();

        public string AddCategory(CategoryViewModel model)
        {
            var category = new Category()
            {
                Name = model.Name,
                DepartmentId = model.DepartmentId,
                Active = true,
                Createdby = model.Createdby,
                CreatedDate = DateTime.Now
            };
            _db.Categories.Add(category);
            int Saved = _db.SaveChanges();
            return Saved > 0 ? "Category Saved" : "Not Saved";
        }


        public List<CategoryViewModel> GetAllCategory()
        {
            try
            {
                //var query = (from category in _db.Categories
                //             join department in _db.Departments on category.DepartmentId equals department.DepartmentId
                //             where category.Active == true && department.Active == true
                //             select new CategoryViewModel()
                //             {
                //                 DepartmentName = department.Name,
                //                 Name = category.Name,
                //                 CategoryId = category.CategoryId
                //             }).ToList();
                //return query;
                var query = _db.Database.SqlQuery<CategoryViewModel>("sp_GetAllCategory").ToList();
                return query;
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        public CategoryViewModel Edit(int id)
        {
            try
            {
                var query = (from category in _db.Categories
                             join department in _db.Departments on category.CategoryId equals department.DepartmentId
                             where category.CategoryId == id && category.Active == true
                             select new CategoryViewModel()
                             {
                                 CategoryId = category.CategoryId,
                                 DepartmentName = department.Name,
                                 Name = category.Name
                             });
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }


        public string Update(CategoryViewModel model)
        {
            try
            {
                var category = _db.Categories.Where(x => x.CategoryId == model.CategoryId).SingleOrDefault();
                if (category != null)
                {
                    category.DepartmentId = model.DepartmentId;
                    category.Name = model.Name;
                    category.ModifyBy = model.ModifyBy;
                    category.ModifyDate = DateTime.Now;
                    int Saved = _db.SaveChanges();
                    return Saved > 0 ? "Saved" : "Not saved";
                }
                return "not Saved";
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        public string Deactive(int id, int userId)
        {
            try
            {
                var category = _db.Categories.Where(x => x.CategoryId == id).SingleOrDefault();
                if (category != null)
                {
                    category.Active = false;
                    category.ModifyBy = userId;
                    category.ModifyDate = DateTime.Now;
                    int saved = _db.SaveChanges();
                    return saved > 0 ? "Saved" : "Not saved";
                }
                return "Not saved";
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        public static List<CategoryViewModel> CategoryList()
        {
            try
            {
                LibraryManagementSystemEntities _db = new LibraryManagementSystemEntities();
                return (from category in _db.Categories
                        where category.Active == true
                        select new CategoryViewModel()
                        {
                            CategoryId = category.CategoryId,
                            Name = category.Name
                        }).ToList();
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }
    }
}