using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.ViewModel
{
    public class IssuedBookViewModel
    {
        public int IssuedBookId { get; set; }
        public int? MemberId { get; set; }
        public int? BookId { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Issuedfor { get; set; }
        public string Remains { get; set; }
        public string BookStatus { get; set; }
        public int? PerdayFine { get; set; }
        public int? Discount { get; set; }
        public int? FinePaid { get; set; }
        public bool? Active { get; set; }
        public int? Createdby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}