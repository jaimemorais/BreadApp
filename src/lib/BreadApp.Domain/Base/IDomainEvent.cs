using MediatR;
using System;

namespace BreadApp.Domain.Base
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }

        DateTime EventDateTime { get; }
    }
}