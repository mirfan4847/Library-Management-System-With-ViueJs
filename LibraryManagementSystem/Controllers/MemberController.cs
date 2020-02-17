using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LibraryManagementSystem.ViewModel;
using LibraryManagementSystem.Repository;
using LibraryManagementSystem.ExceptionManager;
using LibraryManagementSystem.Common;

namespace LibraryManagementSystem.Controllers
{
    public class MemberController : Controller
    {
        MemberRepository _Repository = new MemberRepository();
        // GET: Member
        public ActionResult Index()
        {
            MemberViewModel model = new MemberViewModel();

            return View(model);
        }

        public ActionResult AddMember()
        {
            try
            {
                MemberViewModel model = new MemberViewModel();
                model.Classes = ClassRepository.AllClass();
                return View(model);
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        [HttpPost]
        public ActionResult AddMember(MemberViewModel model)
        {
            try
            {
                model.CreatedBy = Convert.ToInt32(Session[SessionVariable.UserId]);
                model.Active = true;
                model.CreatedDate = DateTime.Now;
                var memberResult = _Repository.AddMemeber(model);
                if (memberResult == "Added")
                    return View("Index");
                else
                    return View();
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }


        public ActionResult GetStudentByClassId(int ClassId)
        {
            try
            {
                MemberViewModel model = new MemberViewModel();
                model.Students = StudentRepository.AllStudent(ClassId);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }


        public ActionResult GetStudentByStudentId(int studentId)
        {
            try
            {
                var objStudent = StudentRepository.GetStudentByStudentId(studentId);
                return Json(objStudent, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        public ActionResult GetStudentDetailByRollNo(string RollNo)
        {
            try
            {
                return Json(StudentRepository.GetStudentDetailByRollNo(RollNo), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }
    }
}