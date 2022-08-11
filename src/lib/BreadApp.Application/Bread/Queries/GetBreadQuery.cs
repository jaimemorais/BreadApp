using ErrorOr;
using MediatR;
using System;

namespace BreadApp.Application.Bread.Queries;

public record GetBreadQuery(Guid Id) : IRequest<ErrorOr<Domain.Entities.Bread>>;
