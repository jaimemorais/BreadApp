using BreadApp.Application.Interfaces.Auth;
using BreadApp.Application.Interfaces.Persistence;
using BreadApp.Domain.Entities;
using System;

namespace BreadApp.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }


        public AuthResult Register(string name, string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception($"User {email} already exists.");
            }

            User newUser = new()
            {
                Name = name,
                Email = email,
                Password = password
            };

            _userRepository.Add(newUser);

            string token = _jwtTokenGenerator.GenerateToken(newUser);

            return new AuthResult(newUser, token);
        }

        public AuthResult Login(string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception($"Login failed.");
            }

            if (user.Password != password)
            {
                throw new Exception("Login failed.");
            }

            string token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthResult(user, token);
        }

    }
}
