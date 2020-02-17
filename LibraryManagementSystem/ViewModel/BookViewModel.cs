using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;

namespace LibraryManagementSystem.ViewModel
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public int? CategoryId { get; set; }

        [DisplayName("Book Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [DisplayName("Book ISBN Number")]
        public string ISBNNumber { get; set; }

        [DisplayName("Available Book Number")]
        public string AvailableBookNumber { get; set; }

        [DisplayName("Writer Name")]
        public string AuthorName { get; set; }

        [DisplayName("Book Addition")]
        public string Addition { get; set; }
        public bool? Status { get; set; }

        [DisplayName("Book Type")]
        public string Type { get; set; }

        [DisplayName("Book Condition")]
        public string Condition { get; set; }

        public string Image { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifyBy { get; set; }


        public string Message { get; set; }

        public string CategoryName { get; set; }

        public List<CategoryViewModel> categoryList { get; set; }
    }
}