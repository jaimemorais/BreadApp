using ErrorOr;
using MediatR;
using System;

namespace BreadApp.Application.Recipe.Commands;


public record PublishRecipeCommand(string UserEmail, Guid RecipeId) : IRequest<ErrorOr<Domain.Entities.Recipe>>;
