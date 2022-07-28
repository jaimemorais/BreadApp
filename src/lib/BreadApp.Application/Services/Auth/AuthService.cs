using BreadApp.Application.Interfaces.Auth;
using System;

namespace BreadApp.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthResult Register(string name, string email, string password)
        {
            // TODO Check if user exists / create user


            Guid userId = Guid.NewGuid();
            string token = _jwtTokenGenerator.GenerateToken(userId, name);

            return new AuthResult(userId, name, email, token);
        }

        public AuthResult Login(string email, string password)
        {
            // TODO
            return new AuthResult(Guid.NewGuid(), "2", "3", "4");
        }

    }
}
