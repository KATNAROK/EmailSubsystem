using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmailSubsystem_SendGrid_WebApp_.Models.HelperClasses;


namespace EmailSubsystem_SendGrid_WebApp_.Controllers
{
    public class EmailController : Controller
    {
        private EmailManager _sendGridEmail;

        public EmailController()
        {
            _sendGridEmail = new EmailManager();
        }

        public ActionResult SendRequestEmail()
        {
            _sendGridEmail = new EmailManager();

            var response = _sendGridEmail.SendRCEmail();

            return Content("Your Email's MessageID: " + response.UniqueMessageId, "application/json");
        }

        // SEND: Email
        public ActionResult Index()
        {
            return View();
        }


    }
}