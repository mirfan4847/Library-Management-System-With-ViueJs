using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LibraryManagementSystem.Repository;
using LibraryManagementSystem.ViewModel;
using LibraryManagementSystem.ExceptionManager;
using LibraryManagementSystem.Common;

namespace LibraryManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository _Repository = new CategoryRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCategory()
        {
            try
            {
                CategoryViewModel model = new CategoryViewModel();
                model.DepartmentList = DepartmentRepository.DepartmentList();
                return View(model);
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }

        }

        [HttpPost]
        public JsonResult AddCategory(CategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Createdby = Convert.ToInt32(Session[SessionVariable.UserId]);
                    return Json(_Repository.AddCategory(model), JsonRequestBehavior.AllowGet);
                }
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }

        }

        public JsonResult GetAllCategory()
        {
            try
            {
                return Json(_Repository.GetAllCategory(), JsonRequestBehavior.AllowGet);
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

        public JsonResult Update(CategoryViewModel model)
        {
            try
            {
                model.ModifyBy = Convert.ToInt32(Session[SessionVariable.UserId]);
                return Json(_Repository.Update(model), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        public JsonResult Deactive(int id)
        {
            try
            {
                return Json(_Repository.Deactive(id, Convert.ToInt32(Session[SessionVariable.UserId])), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }
    }
}