using System;
using System.Collections.Generic;

#nullable disable

namespace TeamManagement.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Courses = new HashSet<Course>();
        }

        public string SemId { get; set; }
        public string SemName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
