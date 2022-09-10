using BreadApp.Application.Common.Interfaces.Email;
using System;
using System.Threading.Tasks;

namespace BreadApp.Infrastructure.Email
{
    public class SendgridMailService : IEmailSenderService
    {
        public async Task SendMailAsync(string toEmail, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
