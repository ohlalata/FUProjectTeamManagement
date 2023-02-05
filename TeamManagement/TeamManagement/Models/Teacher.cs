using System;
using System.Collections.Generic;

#nullable disable

namespace TeamManagement.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Courses = new HashSet<Course>();
        }

        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherPhone { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
