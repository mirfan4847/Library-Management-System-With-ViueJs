using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.ViewModel
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? DepartmentId { get; set; }
        public bool? Active { get; set; }
        public int? Createdby { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }

        public List<DepartmentViewModel> DepartmentList { get; set; }
        public string DepartmentName { get; set; }

        public int Books { get; set; }
    }
}