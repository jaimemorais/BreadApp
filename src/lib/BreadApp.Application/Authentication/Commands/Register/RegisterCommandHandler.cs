using BreadApp.Application.Interfaces.Auth;
using BreadApp.Application.Interfaces.Persistence;
using BreadApp.Domain.Entities;
using BreadApp.Domain.Errors;
using ErrorOr;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadApp.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthResult>> Handle(RegisterCommand registerCommand, CancellationToken cancellationToken)
        {

            if (_userRepository.GetUserByEmail(registerCommand.Email) is not null)
            {
                return UserErrors.DuplicateEmail;
            }

            User newUser = new()
            {
                Name = registerCommand.Name,
                Email = registerCommand.Email,
                Password = registerCommand.Password
            };

            _userRepository.Add(newUser);

            string token = _jwtTokenGenerator.GenerateToken(newUser);

            return new AuthResult(newUser, token);

        }
    }

}
