using ErrorOr;
using MediatR;
using System.Collections.Generic;

namespace BreadApp.Application.Bread.Commands;

public record CreateBreadCommand(string Name, string Description, List<string> Tags) : IRequest<ErrorOr<Domain.Entities.Bread>>;
