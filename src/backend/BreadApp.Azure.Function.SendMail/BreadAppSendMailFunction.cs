using Azure.Messaging;
using BreadApp.Application.Common.Interfaces.Email;
using BreadApp.Domain.DomainEvents;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace BreadApp.Azure.Function.SendMail
{
    // Default URL for triggering event grid function in the local environment.
    // http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

    public class BreadAppSendMailFunction
    {
        private readonly ILogger _logger;
        private readonly IEmailSenderService _emailSenderService;

        public BreadAppSendMailFunction(ILoggerFactory loggerFactory, IEmailSenderService emailSenderService)
        {
            _logger = loggerFactory.CreateLogger<BreadAppSendMailFunction>();
            _emailSenderService = emailSenderService;
        }

        [Function("BreadAppSendMailFunction")]
        public async Task Run([EventGridTrigger] CloudEvent input)
        {
            NewUserRegisteredDomainEvent? newUserRegisteredDomainEvent = input?.Data?.ToObjectFromJson<NewUserRegisteredDomainEvent>();

            if (newUserRegisteredDomainEvent == null)
            {
                _logger.LogError("newUserRegisteredDomainEvent is null");
                return;
            }

            await _emailSenderService.SendMailAsync(newUserRegisteredDomainEvent.UserEmail,
                "Welcome to BreadApp!", $"Welcome to BreadApp {newUserRegisteredDomainEvent.UserName} !");

            _logger.LogInformation($"Email sent. Data : {input?.Data}");
        }
    }

}
