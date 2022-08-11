using ErrorOr;
using MediatR;

namespace BreadApp.Application.Auth.Commands.Register
{
    public record RegisterCommand(string Name, string Email, string Password) : IRequest<ErrorOr<AuthResult>>;

}
