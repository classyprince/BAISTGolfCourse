using BAISTGolfCourse.BLL.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BAISTGolfCourse.BLL.ServiceImpl
{
    public class EmailService : IEmailService
    {
        private readonly string _welcomeEmailPath = "/EmailTemplates/WelcomeEmailTemplate.html";
        private readonly string _sponsorEmailPath = "/EmailTemplates/SponsorEmailTemplate.html";

        public void SendEmailToApplicant(string emailAddress, string firstName)
        {
            var messageHtmlFile = HttpContext.Current.Server.MapPath(_welcomeEmailPath);

            string content = File.ReadAllText(messageHtmlFile);

            content = content.Replace("$userName$", firstName);

            var message = new MailMessage("\"BAISTGolfClub\" <calebd44@gmail.com>",
                emailAddress)
            {
                Subject = "Thank you for signing up to BAIST Golf Club!. We will contact you soon",
                Body = content,
                IsBodyHtml = true

            };

            var client = new SmtpClient();
            client.Send(message);
        }

        public void SendEmailToSponsors(string emailAddress, string applicantName, string firstName)
        {
            var messageHtmlFile = HttpContext.Current.Server.MapPath(_sponsorEmailPath);

            string content = File.ReadAllText(messageHtmlFile);

            content = content.Replace("$userName$", firstName);
            content = content.Replace("$applicantName$", firstName);

            var message = new MailMessage("\"BAISTGolfClub\" <calebd44@gmail.com>",
                emailAddress)
            {
                Subject = "An applicant has referenced you!",
                Body = content,
                IsBodyHtml = true

            };

            var client = new SmtpClient();
            client.Send(message);
        }
    }
}
