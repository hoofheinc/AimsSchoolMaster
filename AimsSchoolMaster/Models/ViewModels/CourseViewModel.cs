using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AimsSchoolMaster.Models
{
    public class AddCourseViewModel
    {
        [Required]
        [Display(Name = "Course Name ")]
        public string CourseName { get; set; }
    }

    public class CourseStudentViewModel
    {
        [Required]
        [Display(Name = "Course Name ")]
        public string CourseID { get; set; }

        [Display(Name = "Student")]
        public string StudentID { get; set; }

        [NotMapped]
        public List<StudentUserProfile> StudentCollection { get; set; }

        [NotMapped]
        public List<Course> CourseCollection { get; set; }
    }

    public class CourseTeacherViewModel
    {
        [Required]
        [Display(Name = "Course Name ")]
        public string CourseID { get; set; }

        [Display(Name = "Teacher")]
        public string TeacherID { get; set; }

        [NotMapped]
        public List<TeacherUserProfile> TeacherCollection { get; set; }

        [NotMapped]
        public List<Course> CourseCollection { get; set; }
    }
}