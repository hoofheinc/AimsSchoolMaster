using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AimsSchoolMaster.Models
{
    public class CotactViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Phone]
        public string Phone { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}