using System;
using System.Collections.Generic;

namespace SBSCLearn.Models
{
    public partial class Courses
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}
