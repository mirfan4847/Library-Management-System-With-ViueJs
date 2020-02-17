using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModel;
using LibraryManagementSystem.ExceptionManager;

namespace LibraryManagementSystem.Repository
{
    public class BookRepository
    {
        LibraryManagementSystemEntities _db = new LibraryManagementSystemEntities();

        public string AddBook(BookViewModel model)
        {
            try
            {
                var book = new Book()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Addition = model.Addition,
                    AuthorName = model.AuthorName,
                    AvailableBookNumber = model.AvailableBookNumber,
                    Condition = model.Condition,
                    CreatedBy = model.CreatedBy,
                    CreatedDate = DateTime.Now,
                    Image = model.Image,
                    ISBNNumber = model.ISBNNumber,
                    Status = model.Status,
                    Type = model.Type,
                    Active = true,
                };
                _db.Books.Add(book);
                int saved = _db.SaveChanges();
                if (saved > 0)
                    return model.Message = "Book Successfully Saved";
                else
                    return model.Message = "Not Saved";
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }


        public List<BookViewModel> GetAllBook()
        {
            try
            {


                //var bookresult = (from book in _db.Books
                //                  //join category in _db.Categories on book.CategoryId equals category.CategoryId
                //                  where book.Active == true 
                //                  select new BookViewModel()
                //                  {
                //                      BookId = book.BookId,
                //                      Name = book.Name,
                //                      Type = book.Type,
                //                      ISBNNumber = book.ISBNNumber,
                //                      //CategoryName = category.Name,
                //                      AuthorName = book.AuthorName,
                //                      AvailableBookNumber = book.AvailableBookNumber
                //                  }).OrderBy(x => x.Name).ToList();

                return _db.Database.SqlQuery<BookViewModel>("sp_GetAllBooks").ToList();
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }


        public BookViewModel Edit(int id)
        {
            try
            {
                var query = (from book in _db.Books
                             join category in _db.Categories on book.CategoryId equals category.CategoryId
                             where book.BookId == id && book.Active == true
                             select new BookViewModel()
                             {
                                 Addition = book.Addition,
                                 AuthorName = book.AuthorName,
                                 AvailableBookNumber = book.AvailableBookNumber,
                                 BookId = book.BookId,
                                 CategoryName = category.Name,
                                 Condition = book.Condition,
                                 Description = book.Description,
                                 ISBNNumber = book.ISBNNumber,
                                 Name = book.Name,
                                 Status = book.Status,
                                 Type = book.Type,
                                 CategoryId = book.CategoryId
                             });
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                RepositoryException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }

        public string update(BookViewModel model)
        {
            var book = _db.Books.Where(x => x.BookId == model.BookId).SingleOrDefault();
            if (book != null)
            {

                book.Addition = model.Addition;
                book.AuthorName = model.AuthorName;
                book.AvailableBookNumber = model.AvailableBookNumber;
                book.Condition = model.Condition;
                book.Description = model.Description;
                book.ISBNNumber = model.ISBNNumber;
                book.Name = model.Name;
                book.Status = model.Status;
                book.Type = model.Type;
                book.CategoryId = model.CategoryId;
                book.ModifyBy = model.ModifyBy;
                book.ModifyDate = DateTime.Now;

                int update = _db.SaveChanges();
                return update > 0 ? "Record updated" : "Not update";
            }
            return "Not update";
        }

        public bool Deactive(int id,int userId)
        {
            try
            {
                var book = _db.Books.Where(x => x.BookId == id).SingleOrDefault();
                if (book != null)
                {
                    book.Active = false;
                    book.ModifyBy = userId;
                    book.ModifyDate = DateTime.Now;

                    int deactive = _db.SaveChanges();
                    return deactive > 0 ? true : false;
                }
                return false;
            }
            catch (Exception ex)
            {
                ControllerException.WriteExceptionMessageToFile(ex.Message, ex);
                return false;
            }
           
        }
    }
}