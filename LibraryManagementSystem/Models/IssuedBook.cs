//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class IssuedBook
    {
        public int IssuedBookId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<int> BookId { get; set; }
        public Nullable<System.DateTime> IssuedDate { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public string Issuedfor { get; set; }
        public string Remains { get; set; }
        public string BookStatus { get; set; }
        public Nullable<int> PerdayFine { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<int> FinePaid { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> Createdby { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
    }
}
