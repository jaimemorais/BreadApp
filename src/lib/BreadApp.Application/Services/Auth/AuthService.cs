namespace BreadApp.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        public AuthResult Login(string email, string password)
        {
            // TODO
            return new AuthResult("1", "2", "3", "4");
        }

        public AuthResult Register(string name, string email, string password)
        {
            // TODO
            return new AuthResult("1", "2", "3", "4");
        }
    }
}
