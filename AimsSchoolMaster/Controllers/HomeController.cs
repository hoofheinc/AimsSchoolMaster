using AimsSchoolMaster.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net.Mail;
using System.IO;

namespace AimsSchoolMaster.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Goals()
        {
            return View();
        }

        public ActionResult Report()
        {
            var path = Server.MapPath(@"~/Content/docs/Letter-Inspection-Report.pdf");
            var fileStream = new FileStream(path,
                                     FileMode.Open,
                                     FileAccess.Read
                                   );
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            return fsResult;
            //return View();
        }

        public ActionResult Grade9()
        {
            return View();
        }

        public ActionResult Grade10()
        {
            return View();
        }

        public ActionResult Grade11()
        {
            return View();
        }

        public ActionResult Grade12()
        {
            return View();
        }

        public ActionResult OurPolicies()
        {
            return View();
        }

        public ActionResult NewsEvents()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        //
        // POST: /Home/Contact
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(CotactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var name = model.Name.Trim();
                var email = model.Email.Trim();
                var phone = model.Phone.Trim();
                var msg = model.Message.Trim();
                var message = string.Empty;
                message += "Name " + name + "<br/>";
                message += "Email " + email + "<br/>";
                message += "Phone " + phone + "<br/>";
                message += "Message " + msg + "<br/>";
                //const string server = "aimsschool.ca";
                const string server = "email-smtp.us-west-2.amazonaws.com";
                const int Port = 587;
                var mm = new MailMessage();
                mm.To.Add("ahschool284@gmail.com");
                //mm.To.Add("maninder.7835@gmail.com");
                mm.From = new MailAddress("support@aimsschool.ca");
                mm.Subject = "Enquiry Aims High school";
                mm.IsBodyHtml = true; // enumeration
                mm.Priority = MailPriority.High; // enumeration
                mm.Body = message;
                var c = new SmtpClient(server, Port)
                {
                    Credentials = new System.Net.NetworkCredential("AKIAI5MJS5OCU3TNKLPQ", "AtWz1r4Ds19n1jJa/cPiRrrtGZb6Kzx+9J7JoVkgmca7"),
                    EnableSsl = true
                };
                //c.Send(mm);
                mm = null;
                ViewBag.Message = "Your enquiry sent successfully";
                ModelState.Clear();
                return View();
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}