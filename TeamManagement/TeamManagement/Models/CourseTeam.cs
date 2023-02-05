using System;
using System.Collections.Generic;

#nullable disable

namespace TeamManagement.Models
{
    public partial class CourseTeam
    {
        public string TeamId { get; set; }
        public string CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Team Team { get; set; }
    }
}
