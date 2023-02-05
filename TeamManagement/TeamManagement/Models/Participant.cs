using System;
using System.Collections.Generic;

#nullable disable

namespace TeamManagement.Models
{
    public partial class Participant
    {
        public string CourseId { get; set; }
        public string StuId { get; set; }
        public string TeamId { get; set; }
        public string InCourse { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Stu { get; set; }
        public virtual Team Team { get; set; }
    }
}
