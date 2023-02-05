using System;
using System.Collections.Generic;

#nullable disable

namespace TeamManagement.Models
{
    public partial class TeamTopic
    {
        public string TeamId { get; set; }
        public string TopicId { get; set; }

        public virtual Team Team { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
