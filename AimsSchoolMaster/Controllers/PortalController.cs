using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AimsSchoolMaster.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AimsSchoolMaster.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.IO;

namespace AimsSchoolMaster.Controllers
{
	public class PortalController : Controller
	{
		private ApplicationSignInManager _signInManager;
		private ApplicationUserManager _userManager;
		private SchoolContext context;
		private string ROLE_STUDENT = "Student";
		private string ROLE_TEACHER = "Teacher";
		private string ROLE_ADMINISTRATOR = "Administrator";

		public PortalController()
		{
			context = SchoolContext.Create();
		}

		public PortalController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
		{
			UserManager = userManager;
			SignInManager = signInManager;
		}

		public ApplicationSignInManager SignInManager
		{
			get
			{
				return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
			}
			private set
			{
				_signInManager = value;
			}
		}

		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

        // GET: Portal
        [Authorize(Roles = "administrator")]
        public ActionResult Home()
		{
			return View();
		}
        [Authorize(Roles = "administrator")]
        public ActionResult AddTeacher()
		{
			return View();
		}

		//
		// POST: /Portal/AddTeacher
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> AddTeacher(AddUserViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser { UserName = model.Email, Email = model.Email, TeacherUserProfile = new TeacherUserProfile() { FullName = string.Format("{0} {1}", model.FirstName, model.LastName), FirstName = model.FirstName, LastName = model.LastName, Id = Guid.NewGuid() } };

				var result = await UserManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					//Assign Role to user Here 
					await this.UserManager.AddToRoleAsync(user.Id, ROLE_TEACHER);
					//Ends Here

					//await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

					// For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
					// Send an email with this link
					// string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
					// var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
					// await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

					return RedirectToAction("Home", "Portal");
				}
				AddErrors(result);
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

        [Authorize(Roles = "administrator")]
        public ActionResult AddStudent()
		{
			return View();
		}

		//
		// POST: /Portal/AddStudent
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> AddStudent(AddUserViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser { UserName = model.Email, Email = model.Email, StudentUserProfile = new StudentUserProfile() { FullName = string.Format("{0} {1}", model.FirstName, model.LastName), FirstName = model.FirstName, LastName = model.LastName, Id = Guid.NewGuid() } };

				var result = await UserManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					//Assign Role to user Here 
					await this.UserManager.AddToRoleAsync(user.Id, ROLE_STUDENT);
					//Ends Here

					//await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

					// For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
					// Send an email with this link
					// string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
					// var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
					// await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

					return RedirectToAction("Home", "Portal");
				}
				AddErrors(result);
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

        [Authorize(Roles = "administrator")]
        public ActionResult AddAdmin()
		{
			return View();
		}

		//
		// POST: /Portal/AddStudent
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
        public async Task<ActionResult> AddAdmin(AddUserViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser { UserName = model.Email, Email = model.Email, AdminUserProfile = new AdminUserProfile() { FullName = string.Format("{0} {1}", model.FirstName, model.LastName), FirstName = model.FirstName, LastName = model.LastName, Id = Guid.NewGuid() } };

				var result = await UserManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					//Assign Role to user Here 
					await this.UserManager.AddToRoleAsync(user.Id, ROLE_ADMINISTRATOR);
					//Ends Here

					// await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

					// For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
					// Send an email with this link
					// string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
					// var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
					// await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

					return RedirectToAction("Home", "Portal");
				}
				AddErrors(result);
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

        [Authorize(Roles = "administrator")]
        public ActionResult AddCourse()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
        public ActionResult AddCourse(AddCourseViewModel model)
		{
			if (ModelState.IsValid)
			{
				var course = new Course() { CourseName = model.CourseName, Id = Guid.NewGuid() };
				//var userlist = context.Users.ToList();
				//adminRole.ToList()[0].Id


				//var userlist = context.Users.Where(s=> s..);
				context.Courses.Add(course);
				context.SaveChanges();
				return RedirectToAction("Home", "Portal");
			}
			return View(model);
		}

		public ActionResult CourseStudent()
		{
			var courseStudent = new CourseStudentViewModel();
			var studentList = context.Users.Where(m => m.StudentUserProfile != null).Select(m => m.StudentUserProfile).ToList<StudentUserProfile>();
			courseStudent.StudentCollection = studentList;
			courseStudent.CourseCollection = context.Courses.ToList();
			return View(courseStudent);
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult CourseStudent(CourseStudentViewModel model)
		{
			if (ModelState.IsValid)
			{
				var course = context.Courses.Include(c => c.StudentUserProfile).Single(m => m.Id.ToString() == model.CourseID);
				var studentList = context.Users.Where(m => m.StudentUserProfile != null).Select(m => m.StudentUserProfile).ToList<StudentUserProfile>();
				var student = studentList.Single(s => s.Id.ToString() == model.StudentID);
				course.StudentUserProfile.Add(student);
				context.SaveChanges();

				return RedirectToAction("Home", "Portal");
			}
			return View(model);
		}

		public ActionResult CourseTeacher()
		{
			var courseTeacher = new CourseTeacherViewModel();
			var teacherList = context.Users.Where(m => m.TeacherUserProfile != null).Select(m => m.TeacherUserProfile).ToList<TeacherUserProfile>();
			courseTeacher.TeacherCollection = teacherList;
			courseTeacher.CourseCollection = context.Courses.ToList();
			return View(courseTeacher);
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult CourseTeacher(CourseTeacherViewModel model)
		{
			if (ModelState.IsValid)
			{
				var course = context.Courses.Include(c => c.TeacherUserProfile).Single(m => m.Id.ToString() == model.CourseID);
				var teacherList = context.Users.Where(m => m.TeacherUserProfile != null).Select(m => m.TeacherUserProfile).ToList<TeacherUserProfile>();
				var teacher = teacherList.Single(s => s.Id.ToString() == model.TeacherID);
				course.TeacherUserProfile.Add(teacher);
				context.SaveChanges();

				return RedirectToAction("Home", "Portal");
			}
			return View(model);
		}

		public ActionResult ListStudent()
		{
			return View();
		}

		public ActionResult ListTeacher()
		{
			return View();
		}

		public JsonResult GetStudentList()
		{
			try
			{
				var studentlist = GetStudentProfileList().Select( e => new { e.FullName, e.User.Email, e.UserID });
				var result =  Json(studentlist, JsonRequestBehavior.AllowGet);

				return result;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public List<StudentUserProfile> GetStudentProfileList()
		{
			return context.Users.Where(m => m.StudentUserProfile != null).Select(m => m.StudentUserProfile).ToList<StudentUserProfile>();
		}

        public JsonResult GetTeacherList()
        {
            try
            {
                var teacherlist = GetTeacherProfileList().Select(e => new { e.FullName, e.User.Email });
                var result = Json(teacherlist, JsonRequestBehavior.AllowGet);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TeacherUserProfile> GetTeacherProfileList()
        {
            return context.Users.Where(m => m.TeacherUserProfile != null).Select(m => m.TeacherUserProfile).ToList<TeacherUserProfile>();
        }

        public ActionResult ViewStudent(string Id)
        {
            var studentlist = GetStudentProfileList();
            var student = studentlist.Where(e => e.UserID == Id).FirstOrDefault<StudentUserProfile>();
            var studentViewModel = new StudentViewModel() { StudentName = student.FullName };
            return View(studentViewModel);
        }

        [HttpPost]
        public ActionResult ViewStudent(StudentViewModel model, HttpPostedFileBase postedFile)
        {
            if (postedFile != null)
            {
                string path = Server.MapPath("~/TeacherUploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filename = postedFile.FileName + DateTime.Now;
                postedFile.SaveAs(path + Path.GetFileName(filename));
                ViewBag.Message = "File uploaded successfully.";
            }

            return View(model);
        }

        private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error);
			}
		}
	}
}