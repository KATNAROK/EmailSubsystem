using System;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace EmailSubsystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute().Wait();
            Console.WriteLine("Hello World!");
        }

        static async Task Execute()
        {
            var apiKey = "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";
                //System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY"); Better code.
            var client = new SendGridClient(apiKey);

            
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("emailsubsystemtest@gmail.com", "Console App"),
                Subject = "Hello World from the SendGrid CSharp SDK!",
                //PlainTextContent = "Hello, Email!",
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
            
            msg.AddTo(new EmailAddress("rcar32@student.monash.edu", "Test User"));
            var response = await client.SendEmailAsync(msg);
        }
    }
}