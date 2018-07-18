using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AimsSchoolMaster.Models
{
    [Table("StudentUserProfile")]
    public class StudentUserProfile : UserProfile
    {
        /// <summary>
        /// Constructor required by Entity Framework.
        /// </summary>
        public StudentUserProfile()
        {
            this.Courses = new HashSet<Course>();
            this.Assignments = new HashSet<Assignment>();
        }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}