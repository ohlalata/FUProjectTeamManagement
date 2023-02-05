using System;
using System.Collections.Generic;

#nullable disable

namespace TeamManagement.Models
{
    public partial class Topic
    {
        public string TopicId { get; set; }
        public string TopicName { get; set; }
        public string CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
