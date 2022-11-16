using Azure.Messaging;
using BreadApp.Application.Common.Interfaces.Email;
using BreadApp.Domain.DomainEvents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BreadApp.Azure.Function.SendMail
{
    // Default URL for triggering event grid function in the local environment.
    // http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

    public class BreadAppSendMailFunction
    {
        private readonly ILogger _logger;

        private readonly IEmailSenderService _emailSenderService;

        public BreadAppSendMailFunction(IEmailSenderService emailSenderService, ILoggerFactory loggerFactory)
        {
            _emailSenderService = emailSenderService;
            _logger = loggerFactory.CreateLogger<BreadAppSendMailFunction>();

        }


        [FunctionName("BreadAppSendMailFunction")]
        public async Task Run([EventGridTrigger] CloudEvent e)
        {
            NewUserRegisteredDomainEvent newUserRegisteredDomainEvent = e.Data.ToObjectFromJson<NewUserRegisteredDomainEvent>();


            await _emailSenderService.SendMailAsync(newUserRegisteredDomainEvent.UserEmail,
                "Welcome to BreadApp!", $"Welcome to BreadApp {newUserRegisteredDomainEvent.UserName} !");

            _logger.LogInformation("Email sent. Data : " + e.Data.ToString());
        }
    }
}
