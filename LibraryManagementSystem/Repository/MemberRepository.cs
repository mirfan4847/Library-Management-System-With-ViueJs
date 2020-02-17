using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using LibraryManagementSystem.ExceptionManager;


namespace LibraryManagementSystem.Repository
{
    public class MemberRepository
    {
        LibraryManagementSystemEntities _db = new LibraryManagementSystemEntities();

        public string AddMemeber(MemberViewModel model)
        {
            try
            {
                var member = new Member()
                {
                    StudentId = model.StudentId,
                    Active = model.Active,
                    Createdby = model.CreatedBy,
                    CreatedDate = model.CreatedDate
                };

                _db.Members.Add(member);
                int added = _db.SaveChanges();
                return added > 0 ? "Added" : "Not Added";
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }
    }
}