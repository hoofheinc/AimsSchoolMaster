using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AimsSchoolMaster.Models
{
    public class StudentViewModel
    {
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }
    }
}