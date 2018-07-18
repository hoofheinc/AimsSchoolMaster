using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AimsSchoolMaster.Models
{
    [Table("Course")]
    public class Course
    {
        /// <summary>
        /// Constructor required by Entity Framework.
        /// </summary>
        public Course()
        {
            this.StudentUserProfile = new HashSet<StudentUserProfile>();
            this.TeacherUserProfile = new HashSet<TeacherUserProfile>();
            this.Assignments = new HashSet<Assignment>();
        }
        //[Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Get/set Course name.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string CourseName { get; set; }

        //[Key, ForeignKey("UserProfile")]
        //public string UserProfileID { get; set; }

        public virtual ICollection<StudentUserProfile> StudentUserProfile { get; set; }

        public virtual ICollection<TeacherUserProfile> TeacherUserProfile { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}