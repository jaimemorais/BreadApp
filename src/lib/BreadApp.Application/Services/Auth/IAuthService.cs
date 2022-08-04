using ErrorOr;

namespace BreadApp.Application.Services.Auth
{
    public interface IAuthService
    {
        ErrorOr<AuthResult> Register(string name, string email, string password);
        ErrorOr<AuthResult> Login(string email, string password);
    }
}
