using MediatR;
using System;

namespace BreadApp.Domain.Base
{
    public interface IDomainEvent : INotification
    {
        Guid DomainEventId { get; }

        DateTime DomainEventDateTime { get; }
    }
}