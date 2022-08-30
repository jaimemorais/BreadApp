using BreadApp.Application.Common.Interfaces.Auth;
using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Domain.Entities;
using BreadApp.Domain.Errors;
using ErrorOr;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadApp.Application.Auth.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ErrorOr<AuthResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthResult>> Handle(RegisterUserCommand registerCommand, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(registerCommand.Email) is not null)
            {
                return UserDomainErrors.DuplicateEmail;
            }

            User newUser = new()
            {
                Name = registerCommand.Name,
                Email = registerCommand.Email,
                Password = registerCommand.Password
            };

            _userRepository.Add(newUser);

            string token = _jwtTokenGenerator.GenerateToken(newUser);

            await Task.CompletedTask;

            return new AuthResult(newUser, token);

        }
    }

}
