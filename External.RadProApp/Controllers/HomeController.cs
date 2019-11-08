using DAL.Radio.Context;
using DAL.Radio.Model;
using External.RadProApp.Helpers;
using External.RadProApp.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web.Mvc;
using static Recaptcha.RecaptchaControlMvc;

namespace External.RadProApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        RadioDbContext db = new RadioDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            var model = new EmailViewModel();
            PrepareLandingPage(model);
            return View(model);
        }

        private void PrepareLandingPage(EmailViewModel model)
        {
            var users = GetAll().Where(x => x.LandingPageId == 1).ToList();
            model.GetLandingPageData = users;
        }
        public IEnumerable<LandingPage> GetAll()
        {
            return db.LandingPages.ToList();
        }

        [HttpPost]
        [RequireHttps]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index([Bind(Include = "Id,Email,Name,Phone,Message")] EmailViewModel model)
        {
            if (!await RecaptchaServices.Validate(Request))
            {
                TempData["ErrMessage"] = string.Format("Your request was denied -- Google Recaptcha v.2.0");
            }

            if (ModelState.IsValid)
            {
                GuestEmail set = new GuestEmail
                {
                    Id = model.Id,
                    Email = model.Email,
                    Name = model.Name,
                    Phone = model.Phone,
                    Message = model.Message,
                };

                try
                {
                    var credentialUserName = ConfigurationManager.AppSettings["SendGrid_UserName"];
                    var sendGridPassword = ConfigurationManager.AppSettings["SendGrid_Password"];
                    var message = new MailMessage();

                    using (var smtp = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587)))
                    {
                        message.To.Add(new MailAddress(model.Email));
                        String bodyBuilder = "";
                        message.From = new MailAddress("benjamin.linde@gmail.com");
                        message.Subject = "RadProSite Auto Response";
                        using (StreamReader read = new StreamReader(Server.MapPath("~/Views/Shared/EmailTemplates/AutoResponseTheme.html")))
                        {
                            bodyBuilder += read.ReadToEnd();
                        }
                        message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(bodyBuilder, null, MediaTypeNames.Text.Html));
                        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        NetworkCredential credentials = new NetworkCredential(credentialUserName, sendGridPassword);
                        smtp.EnableSsl = true;
                        smtp.Credentials = credentials;
                        await smtp.SendMailAsync(message);
                    }

                    set.Status = "Potential";
                    set.UserIpAddress = HttpContext.Request.UserHostAddress;
                    set.ReceivedDate = DateTime.UtcNow;
                    db.GuestEmails.Add(set);
                    TempData["message"] = string.Format("Yes " + "{0} we received your email.", model.Name);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "Home", "Index"));
                }
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrMessage"] = string.Format("Your contact form was incomplete!");
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Employment()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult TermsOfUse()
        {
            return View();
        }
    }
}
