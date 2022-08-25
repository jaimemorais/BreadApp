using BreadApp.Domain.ValueObjects;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;

namespace BreadApp.Application.Recipe.Commands;


public record AddRecipeCommand(string UserEmail, string Name, DateTime Date, string Instructions, List<Ingredient> Ingredients, List<string> Tags) : IRequest<ErrorOr<Domain.Entities.Recipe>>;
