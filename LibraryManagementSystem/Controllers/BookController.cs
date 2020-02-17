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
    public class BookController : Controller
    {
        BookRepository _Repository = new BookRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddBook()
        {
            BookViewModel model = new BookViewModel();
            model.categoryList = CategoryRepository.CategoryList();
            return View(model);
        }

        [HttpPost]
        public JsonResult AddBook(BookViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (model.BookId == 0)
                        return Json(_Repository.AddBook(model), JsonRequestBehavior.AllowGet);
                    else
                        return Json(_Repository.update(model), JsonRequestBehavior.AllowGet);
                }
                return Json("Not Saved", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        public JsonResult GetAllBook()
        {
            try
            {
                return Json(_Repository.GetAllBook(), JsonRequestBehavior.AllowGet);
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
                BookViewModel model = new BookViewModel();
                model = _Repository.Edit(id);
                model.categoryList = CategoryRepository.CategoryList();
                return View("AddBook", model);
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }
    }
}