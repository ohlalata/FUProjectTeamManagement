using System;
using System.Collections.Generic;

#nullable disable

namespace TeamManagement.Models
{
    public partial class Course
    {
        public Course()
        {
            Topics = new HashSet<Topic>();
        }

        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string SubId { get; set; }
        public string SemId { get; set; }
        public string TeacherId { get; set; }

        public virtual Semester Sem { get; set; }
        public virtual Subject Sub { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
