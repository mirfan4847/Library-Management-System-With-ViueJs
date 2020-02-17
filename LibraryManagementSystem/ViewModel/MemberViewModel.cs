using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.ViewModel
{
    public class MemberViewModel
    {
        public int MemberId { get; set; }

        public int? ClassId { get; set; }
        public int? StudentId { get; set; }

        public string StudentName { get; set; }

        public string FatherName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string RollNo { get; set; }

        public string RollNumber { get; set; }

        public bool? Active { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public List<StudentViewModel> Students { get; set; }

        public List<ClassViewModel> Classes { get; set; }

    }
}