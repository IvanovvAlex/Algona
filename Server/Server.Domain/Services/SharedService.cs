using Server.Common.Requests.ContactRequests;
using Server.Domain.Interfaces;
using System.Net.Mail;

using static Server.Common.Constants.GlobalConstants;

namespace Server.Domain.Services
{
    public class SharedService : ISharedService
    {
        public SharedService() {}

        public async Task EmailSender(CreateContactRequest request)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(request.Email);
                mail.To.Add(new MailAddress(MainEmail));

                mail.Body = $"<p>From: {request.Name}</p> <p>Email: {request.Email}</p> <p>Content: {request.Description}</p>";

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
