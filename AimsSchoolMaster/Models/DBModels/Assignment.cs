using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AimsSchoolMaster.Models
{
    [Table("Assignment")]
    public class Assignment
    {
        /// <summary>
        /// Constructor required by Entity Framework.
        /// </summary>
        public Assignment()
        {
            this.StudentUserProfile = new HashSet<StudentUserProfile>();
            this.Courses = new HashSet<Course>();
        }

        public Guid Id { get; set; }

        /// <summary>
        /// Get/set Assignment name.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string AssignmentName { get; set; }

        [Required]
        public string AssignmentPath { get; set; }

        /// <summary>
        /// Get/set local Assignment name.
        /// </summary>
        public string DriveAssignmentName { get; set; }

        public virtual ICollection<StudentUserProfile> StudentUserProfile { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}