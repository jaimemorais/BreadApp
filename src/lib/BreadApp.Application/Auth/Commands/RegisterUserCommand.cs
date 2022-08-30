using ErrorOr;
using MediatR;

namespace BreadApp.Application.Auth.Commands
{
    public record RegisterUserCommand(string Name, string Email, string Password) : IRequest<ErrorOr<AuthResult>>;

}
