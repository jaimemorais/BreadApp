using BreadApp.Application.Common.Interfaces.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace BreadApp.Infrastructure.Email
{
    public class SendgridMailService : IEmailSenderService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<SendgridMailService> _logger;

        public SendgridMailService(IConfiguration config, ILogger<SendgridMailService> logger)
        {
            _config = config;
            _logger = logger;
        }


        public async Task SendMailAsync(string toEmail, string subject, string body)
        {
            string apiKey = _config["BreadApp_SendGrid_ApiKey"];
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("breadapp@breadapp.com", "Bread App");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, subject, subject);

            var response = await client.SendEmailAsync(msg);

            if (!response.IsSuccessStatusCode)
            {
                // TODO metrics
                _logger.LogError("Error sending mail - StatusCode : {0} - Body : {1}", response.StatusCode, response.Body);
            }
        }
    }
}
