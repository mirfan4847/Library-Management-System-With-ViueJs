using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LibraryManagementSystem.Models;
using System.Web.Mvc;
using LibraryManagementSystem.ViewModel;
using LibraryManagementSystem.ExceptionManager;


namespace LibraryManagementSystem.Repository
{
    public class StudentRepository
    {
        public static List<StudentViewModel> AllStudent(int classId)
        {
            try
            {
                LibraryManagementSystemEntities _db = new LibraryManagementSystemEntities();
                var query = (from student in _db.Students
                             where student.Active == true && student.ClassId == classId
                             select new StudentViewModel()
                             {
                                 StudentId = student.StudentId,
                                 StudentName = student.StudentName
                             });
                return query.ToList();
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        public static StudentViewModel GetStudentByStudentId(int studentId)
        {
            try
            {
                LibraryManagementSystemEntities _db = new LibraryManagementSystemEntities();
                var studentobj = (from student in _db.Students
                                  where student.StudentId == studentId && student.Active == true
                                  select new StudentViewModel()
                                  {
                                      StudentId = student.StudentId,
                                      StudentName = student.StudentName,
                                      Email = student.Email,
                                      Address = student.Address,
                                      PhoneNumber = student.PhoneNumber,
                                      RollNo = student.RollNo
                                  }).SingleOrDefault();
                return studentobj;
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        public static StudentViewModel GetStudentDetailByRollNo(string RollNo)
        {
            try
            {
                LibraryManagementSystemEntities _db = new LibraryManagementSystemEntities();
                var studentobj = (from student in _db.Students
                                  where student.RollNo == RollNo && student.Active == true
                                  select new StudentViewModel()
                                  {
                                      StudentId = student.StudentId,
                                      StudentName = student.StudentName,
                                      Email = student.Email,
                                      Address = student.Address,
                                      PhoneNumber = student.PhoneNumber
                                  }).SingleOrDefault();
                return studentobj;
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }
    }
}