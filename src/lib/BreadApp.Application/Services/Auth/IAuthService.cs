namespace BreadApp.Application.Services.Auth
{
    public interface IAuthService
    {
        AuthResult Register(string name, string email, string password);
        AuthResult Login(string email, string password);
    }
}
