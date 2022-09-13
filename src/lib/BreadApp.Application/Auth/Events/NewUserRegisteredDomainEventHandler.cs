using BreadApp.Application.Common.Interfaces.Events;
using BreadApp.Application.Common.Messaging;
using BreadApp.Domain.DomainEvents;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace BreadApp.Application.Auth.Events
{
    public class NewUserRegisteredDomainEventHandler : INotificationHandler<NewUserRegisteredDomainEvent>
    {
        private readonly IConfiguration _config;

        private readonly IBreadAppEventNotificationService _breadAppEventNotificationService;

        public NewUserRegisteredDomainEventHandler(IBreadAppEventNotificationService breadAppEventNotificationService, IConfiguration config)
        {
            _config = config;
            _breadAppEventNotificationService = breadAppEventNotificationService;
        }

        public async Task Handle(NewUserRegisteredDomainEvent notification, CancellationToken cancellationToken)
        {
            await _breadAppEventNotificationService.SendEventAsync(BreadAppMessagingContexts.NEW_USER_SEND_MAIL_CONTEXT, notification);
        }
    }
}
