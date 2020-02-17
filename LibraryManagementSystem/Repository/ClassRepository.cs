using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using LibraryManagementSystem.ExceptionManager;

namespace LibraryManagementSystem.Repository
{
    public class ClassRepository
    {
        public static List<ClassViewModel> AllClass()
        {
            try
            {
                LibraryManagementSystemEntities _db = new LibraryManagementSystemEntities();
                var query = from clas in _db.Classes
                            where clas.Active == true
                            select new ClassViewModel()
                            {
                                ClassId = clas.ClassId,
                                ClassName = clas.ClassName
                            };
                return query.ToList();
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }
    }
}