using System;
using System.Collections.Generic;

#nullable disable

namespace TeamManagement.Models
{
    public partial class Student
    {
        public string StuId { get; set; }
        public string StuName { get; set; }
        public string StuEmail { get; set; }
        public string StuPhone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string StuGender { get; set; }
    }
}
