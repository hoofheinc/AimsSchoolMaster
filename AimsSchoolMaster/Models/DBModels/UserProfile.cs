using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AimsSchoolMaster.Models
{
    public class UserProfile
    {

        /// <summary>
        /// Constructor required by Entity Framework.
        /// </summary>
        public UserProfile()
        {
        }
        //[Key]
        public Guid Id { get; set; }

        [Key, ForeignKey("User")]
        public string UserID { get; set; }

        /// <summary>
        /// Get/set full user name.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string FullName { get; set; }

        /// <summary>
        /// Get/set user first name.
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        /// <summary>
        /// Get/set user last name.
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        /// <summary>
        /// Get/set user.
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}