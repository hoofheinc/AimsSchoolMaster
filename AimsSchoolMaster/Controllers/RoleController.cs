using AimsSchoolMaster.Context;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AimsSchoolMaster.Controllers
{
	public class RoleController : Controller
    {
	    private SchoolContext context;

	    public RoleController()
	    {
		    context = new SchoolContext();
	    }

		// GET: Role
		public ActionResult Index()
        {
	        var Roles = context.Roles.ToList();
			return View(Roles);
        }

	    /// <summary>
	    /// Create  a New role
	    /// </summary>
	    /// <returns></returns>
	    public ActionResult Create()
	    {
		    var Role = new IdentityRole();
		    return View(Role);
	    }

	    /// <summary>
	    /// Create a New Role
	    /// </summary>
	    /// <param name="Role"></param>
	    /// <returns></returns>
	    [HttpPost]
	    public ActionResult Create(IdentityRole Role)
	    {
		    context.Roles.Add(Role);
		    context.SaveChanges();
		    return RedirectToAction("Index");
	    }
	}
}