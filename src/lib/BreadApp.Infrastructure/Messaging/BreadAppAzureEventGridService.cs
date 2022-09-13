using Azure;
using Azure.Messaging;
using Azure.Messaging.EventGrid;
using BreadApp.Application.Common.Interfaces.Events;
using BreadApp.Application.Common.Messaging;
using BreadApp.Infrastructure.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace BreadApp.Infrastructure.Messaging
{

    public class BreadAppAzureEventGridService : IBreadAppEventNotificationService
    {
        private readonly IConfiguration _config;

        public BreadAppAzureEventGridService(IConfiguration config)
        {
            _config = config;
        }


        public async Task SendEventAsync(string context, object breadAppEventData)
        {
            (string topic, string topicKey) = GetContextConfig(context);

            EventGridPublisherClient eventGridClient = new(new Uri(topic), new AzureKeyCredential(topicKey));

            var cloudEvent = new CloudEvent(context, breadAppEventData.GetType().Name, breadAppEventData);

            await eventGridClient.SendEventAsync(cloudEvent);

        }

        private (string Topic, string TopicKey) GetContextConfig(string context) => context switch
        {
            BreadAppMessagingContexts.NEW_USER_SEND_MAIL_CONTEXT =>
                (_config["BreadApp:Azure:EventGrid:SendMailTopicEndpoint"], _config["BreadApp:Azure:EventGrid:SendMailTopicAccessKey"]),

            _ => throw new BreadAppInfraException($"Context '{context}' keys not configured")
        };


    }
}
