using System;
using System.Collections.Generic;

#nullable disable

namespace TeamManagement.Models
{
    public partial class TeacherTopic
    {
        public string TeacherId { get; set; }
        public string TopicId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
