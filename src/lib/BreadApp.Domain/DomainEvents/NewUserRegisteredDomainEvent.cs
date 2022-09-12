using BreadApp.Domain.Base;
using System;

namespace BreadApp.Domain.DomainEvents
{
    public sealed record NewUserRegisteredDomainEvent(Guid UserId, string UserEmail) : IDomainEvent
    {
        public Guid DomainEventId => Guid.NewGuid();

        public DateTime DomainEventDateTime => DateTime.UtcNow;

    }
}
