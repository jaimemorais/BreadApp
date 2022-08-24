using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;

namespace BreadApp.Application.BreadDone.Commands;


public record AddBreadDoneCommand(DateTime Date, string UserEmail, Guid RecipeId, string Comments, List<string> Tags) : IRequest<ErrorOr<Domain.Entities.BreadDone>>;
