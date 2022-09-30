using System.Threading.Tasks;

namespace BreadApp.Application.Common.Interfaces.Email
{
    public interface IEmailSenderService
    {
        Task SendMailAsync(string toEmail, string subject, string bodyPlainText = "", string bodyHtml = "");
    }
}
