using ErrorOr;
using MediatR;
using System;

namespace BreadApp.Application.Recipe.Queries
{
    public record GetRecipeQuery(Guid Id) : IRequest<ErrorOr<Domain.Entities.Recipe>>;
}