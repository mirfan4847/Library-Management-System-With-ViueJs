using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LibraryManagementSystem.ViewModel;
using LibraryManagementSystem.Repository;
using LibraryManagementSystem.ExceptionManager;

namespace LibraryManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentRepository _Repository = new DepartmentRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(DepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Json(_Repository.AddDepartment(model), JsonRequestBehavior.AllowGet);
                }
                return View();
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        public JsonResult GetAllDepartment()
        {
            try
            {
                return Json(_Repository.GetAllDepartment(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }


        public ActionResult Edit(int id)
        {
            try
            {
                return View(_Repository.Edit(id));
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        [HttpPost]
        public JsonResult Edit(DepartmentViewModel model)
        {
            try
            {
                return Json(_Repository.Update(model), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        public ActionResult Deactive(int id)
        {
            try
            {
                return View(_Repository.Deactive(id));
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }
    }
}