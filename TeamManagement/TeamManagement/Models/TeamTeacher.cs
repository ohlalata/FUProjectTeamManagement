using System;
using System.Collections.Generic;

#nullable disable

namespace TeamManagement.Models
{
    public partial class TeamTeacher
    {
        public string TeamId { get; set; }
        public string TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Team Team { get; set; }
    }
}
