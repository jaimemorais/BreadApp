using BreadApp.Application.Interfaces.Auth;
using BreadApp.Application.Interfaces.Persistence;
using BreadApp.Domain.Entities;
using BreadApp.Domain.Errors;
using ErrorOr;

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


        public ErrorOr<AuthResult> Register(string name, string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return UserErrors.DuplicateEmail;
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

        public ErrorOr<AuthResult> Login(string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                return UserErrors.FailedLogin;
            }

            if (user.Password != password)
            {
                return UserErrors.FailedLogin;
            }

            string token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthResult(user, token);
        }

    }
}
