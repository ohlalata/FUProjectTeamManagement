using System;
using System.Collections.Generic;

#nullable disable

namespace TeamManagement.Models
{
    public partial class Department
    {
        public Department()
        {
            Subjects = new HashSet<Subject>();
        }

        public string DeptId { get; set; }
        public string DeptName { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
