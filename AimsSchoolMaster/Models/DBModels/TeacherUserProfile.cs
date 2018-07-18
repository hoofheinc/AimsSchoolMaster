using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AimsSchoolMaster.Models
{
    [Table("TeacherUserProfile")]
    public class TeacherUserProfile : UserProfile
    {
        /// <summary>
        /// Constructor required by Entity Framework.
        /// </summary>
        public TeacherUserProfile()
        {
            this.Courses = new HashSet<Course>();
        }

        public virtual ICollection<Course> Courses { get; set; }
    }
}