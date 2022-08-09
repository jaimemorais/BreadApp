using ErrorOr;
using MediatR;

namespace BreadApp.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string Name, string Email, string Password) : IRequest<ErrorOr<AuthResult>>;

}
