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
    
    public partial class Book
    {
        public int BookId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ISBNNumber { get; set; }
        public string AvailableBookNumber { get; set; }
        public string AuthorName { get; set; }
        public string Addition { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Type { get; set; }
        public string Condition { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string Image { get; set; }
    }
}
