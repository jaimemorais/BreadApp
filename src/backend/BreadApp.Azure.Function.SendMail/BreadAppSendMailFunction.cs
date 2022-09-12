using Azure.Messaging.EventGrid;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;

namespace BreadApp.Azure.Function.SendMail
{


    // Default URL for triggering event grid function in the local environment.
    // http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

    public static class BreadAppSendMailFunction
    {
        [FunctionName("BreadAppSendMailFunction")]
        public static void Run([EventGridTrigger] EventGridEvent eventGridEvent, ILogger log)
        {
            // TODO
            // await _emailSenderService.SendMailAsync(notification.UserEmail, "Welcome to BreadApp!", $"Welcome to BreadApp {notification.UserEmail} !");

            log.LogInformation(eventGridEvent.Data.ToString());
        }
    }
}
