using ErrorOr;
using MediatR;

namespace BreadApp.Application.Authentication.Commands.Register
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthResult>>;

}
