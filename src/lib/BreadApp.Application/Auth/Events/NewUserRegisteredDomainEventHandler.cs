using BreadApp.Application.Common.Interfaces.Events;
using BreadApp.Domain.DomainEvents;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadApp.Application.Auth.Events
{
    public class NewUserRegisteredDomainEventHandler : INotificationHandler<NewUserRegisteredDomainEvent>
    {

        private readonly IBreadAppEventNotificationService _breadAppEventNotificationService;

        public NewUserRegisteredDomainEventHandler(IBreadAppEventNotificationService breadAppEventNotificationService)
        {
            _breadAppEventNotificationService = breadAppEventNotificationService;
        }

        public async Task Handle(NewUserRegisteredDomainEvent notification, CancellationToken cancellationToken)
        {
            await _breadAppEventNotificationService.NotifyEventAsync(notification);
        }
    }
}
