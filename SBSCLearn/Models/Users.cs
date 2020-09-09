using System;
using System.Collections.Generic;

namespace SBSCLearn.Models
{
    public partial class Users
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CourseId { get; set; }
        public string Password { get; set; }
    }
}
