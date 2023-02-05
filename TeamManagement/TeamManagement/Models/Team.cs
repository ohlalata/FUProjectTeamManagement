using System;
using System.Collections.Generic;

#nullable disable

namespace TeamManagement.Models
{
    public partial class Team
    {
        public string TeamId { get; set; }
        public string TeamName { get; set; }
        public int? TeamCount { get; set; }
    }
}
