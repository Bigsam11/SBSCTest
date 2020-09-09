using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SBSCLearn.Models
{
    public class UserViewModel
    {
            [Key]
            public Guid UserId { get; set; }

            public string UserName { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public Guid CourseId { get; set; }

            public int Email { get; set; }
       
    }
}
