using BreadApp.Application.Common.Interfaces.Email;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace BreadApp.Infrastructure.Email
{
    public class SendgridMailService : IEmailSenderService
    {
        private readonly IConfiguration _config;

        public SendgridMailService(IConfiguration config)
        {
            _config = config;
        }


        public async Task SendMailAsync(string toEmail, string subject, string body)
        {
            string apiKey = _config["BreadApp:Sendgrid:ApiKey"];
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("breadapp@breadapp.com", "Bread App");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, subject, subject);

            await client.SendEmailAsync(msg);
        }
    }
}
