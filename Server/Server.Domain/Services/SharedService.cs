using System.Net.Mail;

using Microsoft.Extensions.Configuration;

using Server.Common.Requests.ContactRequests;
using Server.Domain.Interfaces;
using static Server.Common.Constants.GlobalConstants;

using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;


namespace Server.Domain.Services
{
    public class SharedService : ISharedService
    {
        private IConfiguration configuration;

        public SharedService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task EmailSender(CreateContactRequest request)
        {
            /*
             //add this to user secrets
               "MailSettings": {
               "Mail": "someEmail@gmail.com",
               "DisplayName": "Some name",
               "Password": "somePassword",
               "Host": "smtp.gmail.com",
               "Port": 587
             */
            var mailSettings = this.configuration.GetSection("MailSettings");
            var mail = mailSettings["Mail"];
            var displayName = mailSettings["DisplayName"];
            var password = mailSettings["Password"];
            var host = mailSettings["Host"];
            var port = int.Parse(mailSettings["Port"]);


            // Create a message and set up the recipients.

            MailMessage mailToAdmin = new MailMessage();
            mailToAdmin.From = new MailAddress(mail, displayName);
            mailToAdmin.To.Add(mail);
            mailToAdmin.Subject = request.CompanyName;
            StringBuilder body = new StringBuilder();
            body.Append("Name: " + request.Name);
            body.Append(Environment.NewLine);
            body.Append("Company: " + request.CompanyName);
            body.Append(Environment.NewLine);
            body.Append("Email: " + request.Email);
            body.Append(Environment.NewLine);
            body.Append("Phone: " + request.Phone);
            body.Append(Environment.NewLine);
            body.Append("Content: " + request.Description);
            mailToAdmin.Body = body.ToString();

            SmtpClient client = new SmtpClient(host, port);
            client.Credentials = new NetworkCredential(mail, password);
            client.EnableSsl = true;

            client.Send(mailToAdmin);




            // Create a message and set up the recipients.
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(mail, displayName);
            mailMessage.To.Add(request.Email);
            mailMessage.Subject = "ALGONA - Contact Form";

            //Set the html message body.
            string htmlBody = "<html><body>";
            htmlBody += "<h3>Dear ";
            htmlBody += request.Name;
            htmlBody += ",</h3>";
            htmlBody += "<p>We would like to express our sincere gratitude for using the <b>Contact Us</b> feature on our website. Your inquiry is important to us, and we appreciate the opportunity to assist you.</p>";
            htmlBody += "<p>Our team is currently reviewing your message, and we will do our utmost to provide you with a timely and comprehensive response. In the meantime, please feel free to explore our <a href=\"[URL]\">website</a> for additional information that may be helpful.</p>";
            htmlBody += "<p>Here at <b>ALGONA</b>, we are committed to delivering excellent customer service, and your feedback is invaluable to us. We are constantly striving to improve our products, and your input plays a crucial role in this process.</p>";
            htmlBody += "<p>Thank you once again for choosing <b>ALGONA</b>. We look forward to serving you and addressing your needs promptly. If you have any further questions or concerns, please don't hesitate to reach out to us.</p>";
            htmlBody += "<h3>Best regards,<br>The ALGONA team</h3>";
            
            //Encode the image to base64 string.
            string imagePath = "./Images/logo-no-background.png";
            string base64Image = ConvertImageToBase64(imagePath);

            //Add the image to the html body.
            htmlBody += $"<img src='data:image/jpeg;base64,{base64Image}' alt='algona-logo' border=\"0\" style=\"width: 200px; height: auto; margin: 0 auto; display: block;\">";
            htmlBody += "</body></html>";

            mailMessage.Body = htmlBody;
            mailMessage.IsBodyHtml = true;

            // Set up the SMTP client and send the email
            SmtpClient smtpClient = new SmtpClient(host, port);
            smtpClient.Credentials = new NetworkCredential(mail, password);
            smtpClient.EnableSsl = true;

            smtpClient.Send(mailMessage);
        }

        // Function to convert an image to base64
        private static string ConvertImageToBase64(string imagePath)
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageBytes);
        }

        public async Task SendResetPasswordEmail(string toEmail, string resetToken)
        {

            /*
            //add this to user secrets
              "MailSettings": {
              "Mail": "yourEmail@gmail.com",
              "DisplayName": "Your name",
              "Password": "yourEmailPassword",
              "Host": "smtp.gmail.com",
              "Port": 587
            //might have some problems with 2FA emails
            */
            var mailSettings = this.configuration.GetSection("MailSettings");
            var mail = mailSettings["Mail"];
            var displayName = mailSettings["DisplayName"];
            var password = mailSettings["Password"];
            var host = mailSettings["Host"];
            var port = int.Parse(mailSettings["Port"]);

            // Create a message and set up the recipients.
            var fromAddress = new MailAddress(mail,displayName );
            var toAddress = new MailAddress(toEmail);
            const string subject = "Password Reset";
            var body = $"Click the following link to reset your password: {GetResetPasswordLink(resetToken)}";

            // Set up the SMTP client and send the email
            SmtpClient smtpClient = new SmtpClient(host, port);
            smtpClient.Credentials = new NetworkCredential(mail, password);
            smtpClient.EnableSsl = true;

            // Create a message and set up the recipients.
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtpClient.Send(message);
            }
        }

        private static string GetResetPasswordLink(string resetToken)
        {
            return $"https://algona.ltd/auth/resetPassword?token={resetToken}";
        }
    }
}
