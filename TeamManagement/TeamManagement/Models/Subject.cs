using System;
using System.Collections.Generic;

#nullable disable

namespace TeamManagement.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Courses = new HashSet<Course>();
        }

        public string SubId { get; set; }
        public string SubName { get; set; }
        public string DeptId { get; set; }

        public virtual Department Dept { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
