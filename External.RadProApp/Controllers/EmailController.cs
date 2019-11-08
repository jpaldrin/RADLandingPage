using DAL.Radio.Context;
using DAL.Radio.IRepository;
using External.RadProApp.ViewModel;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace External.RadProApp.Controllers
{
    public class EmailController : Controller
    {
        private IEmailRepository emailRepo;

        public EmailController(IEmailRepository _email)
        {
            emailRepo = _email;
        }

        RadioDbContext db = new RadioDbContext();
        // GET: Email
        public ActionResult InBox()
        {
            var model = new EmailViewModel();
            PrepareEmailIndex(model);
            return View();
        }

        public ActionResult Create()
        {
            var model = new EmailViewModel();

            return View();
        }


//        public async Task<ActionResult> Create(EmailViewModel model)
//        {
//            var credentialUserName = ConfigurationManager.AppSettings["SendGrid_UserName"];
//            var sendGridPassword = ConfigurationManager.AppSettings["SendGrid_Password"];

//            var message = new MailMessage();
//            var count = model.ToEmails.Count;
//            using (var smtp = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587)))
//            {
//                foreach (var item in model.ToEmails)
//                {
//                    message.To.Add(new MailAddress(item));
//                        String bodyBuilder = "";
//                    message.From = new MailAddress(User.Identity.Name);
//                    message.Subject = model.EmailSubject;
//                    using (StreamReader read = new StreamReader(Server.MapPath("~/Views/Shared/EmailTemplates/AutoResponseTheme.html")))
//                    {
//                        bodyBuilder += StreamReader.ReadToEnd();
//                    }

//                    message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(bodyBuilder, null, MediaTypeNames.Text.Html));
//                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
//                    smtp.UseDefaultCredentials = false;

//                    NetworkCredential credentials =
//new NetworkCredential(credentialUserName, sendGridPassword);
//                    smtp.EnableSsl = true;
//                    smtp.Credentials = credentials;
//                    if (count > 0)
//                    {
//                        await smtp.SendMailAsync(message);
//                        //db.Emails.Add(email);
//                        TempData["message"] = string.Format("{0} Recipient(s).", model.Email);
//                    }
//                }
//            }
//            TempData["message"] = string.Format("[ {0} ] Emails were sent.", count);
//            return RedirectToAction("InBox");
//        }


        public void PrepareEmailIndex(EmailViewModel model)
        {
            var xy = emailRepo.GetAll().ToList();
            model.GetAllEmails = xy;
        }

        #region Helpers
       
        #endregion
    }
}