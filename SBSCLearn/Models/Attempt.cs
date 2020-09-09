using System;
using System.Collections.Generic;

namespace SBSCLearn.Models
{
    public partial class Attempt
    {
        public Guid? UserId { get; set; }
        public Guid AttemptId { get; set; }
        public Guid? CourseId { get; set; }
        public string CourseName { get; set; }
        public string Category { get; set; }
        public string CourseDescription { get; set; }
        public DateTime AttemptedDate { get; set; }
        public int? Score { get; set; }
    }
}
