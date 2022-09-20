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


        public async Task SendEventAsync(string messagingContext, object breadAppEventData)
        {
            (string topic, string topicKey) = GetContextConfig(messagingContext);

            EventGridPublisherClient eventGridClient = new(new Uri(topic), new AzureKeyCredential(topicKey));

            var cloudEvent = new CloudEvent(messagingContext, breadAppEventData.GetType().Name, breadAppEventData);

            var response = await eventGridClient.SendEventAsync(cloudEvent);

            if (response.IsError)
            {
                string httpError = response.ReasonPhrase;
                // TODO failed event metric / log
            }

        }

        private (string Topic, string TopicKey) GetContextConfig(string messagingContext) => messagingContext switch
        {
            BreadAppMessagingContexts.NEW_USER_SEND_MAIL_CONTEXT =>
                (_config["BreadApp_Azure_EventGrid_SendMailTopicEndpoint"], _config["BreadApp_Azure_EventGrid_SendMailTopicAccessKey"]),

            _ => throw new BreadAppInfraException($"Context '{messagingContext}' keys not configured")
        };


    }
}
