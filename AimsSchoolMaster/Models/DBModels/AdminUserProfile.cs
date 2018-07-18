using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace AimsSchoolMaster.Models
{
    [Table("AdminUserProfile")]
    public class AdminUserProfile : UserProfile
    {
        /// <summary>
        /// Constructor required by Entity Framework.
        /// </summary>
        public AdminUserProfile()
        {
        }

    }
}