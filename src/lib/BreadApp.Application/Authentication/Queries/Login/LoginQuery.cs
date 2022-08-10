using ErrorOr;
using MediatR;

namespace BreadApp.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthResult>>;

}
