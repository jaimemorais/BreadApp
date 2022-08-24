using ErrorOr;
using MediatR;
using System;

namespace BreadApp.Application.BreadDone.Queries
{
    public record GetBreadDoneQuery(Guid Id) : IRequest<ErrorOr<Domain.Entities.BreadDone>>;
}