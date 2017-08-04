using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using SendGrid;

namespace EmailSubsystem_SendGrid_WebApp_.Models.HelperClasses
{
    public class EmailManager
    {
        private readonly SendGridClient _client;
        private string apiKey = "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";
            //Environment.GetEnvironmentVariable("SENDGRID_API_KEY"); Better code.
        private static readonly string MessageId = "X-Message-Id";

        // Should be a singleton pattern implemented?
        public EmailManager()
        {
            _client = new SendGridClient(apiKey);
        }

        public EmailResponse SendRCEmail() // Send Request Confirmation email.
        {

            var emailMessage = new SendGridMessage()
            {
                From = new EmailAddress("emailsubsystemtest@gmail.com", "Console App"),
                Subject = "Hello World from the SendGrid ASP.NET MVC WebApp[Riccardo]!",
                //PlainTextContent = "Hello, Email!", Is this really necessary if all content is made HTML?
                HtmlContent =
                "<html>" +
                    "<body>" +
                    "<a href='http://redsurveillance.azurewebsites.net/' title='RS Portal'><img src='cid:my_image' alt='My Image' border='0' /></a>" +
                    "<br />" +
                    "<h1>My E-mail Title</h1>" +
                    "E-mail content." +
                    "</body>" +
                "</html>"
            };

            emailMessage.AddTo(new EmailAddress("rcar32@student.monash.edu", "Test User"));           

            return ProcessResponse(_client.SendEmailAsync(emailMessage).Result); // Single line of code to send mail async as well as returning the result.
        }

        private EmailResponse ProcessResponse(Response response)
        {// Private so that this is the only class that can invoke it.
            if (response.StatusCode.Equals(System.Net.HttpStatusCode.Accepted)
                || response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
            {
                return ToMailResponse(response);
            }

            // Recode this for better error checking/ error handling.
            var errorResponse = response.Body.ReadAsStringAsync().Result;

            throw new Exception(response.StatusCode.ToString());
        }

        private static EmailResponse ToMailResponse(Response response)
        {
            if (response == null)
                return null;

            var headers = (HttpHeaders)response.Headers;
            var messageId = headers.GetValues(MessageId).FirstOrDefault();
            return new EmailResponse()
            {
                UniqueMessageId = messageId,
                DateSent = DateTime.UtcNow,
            };
        }
    }
}