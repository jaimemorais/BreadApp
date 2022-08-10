﻿using BreadApp.Application.Interfaces.Auth;
using BreadApp.Application.Interfaces.Persistence;
using BreadApp.Domain.Entities;
using BreadApp.Domain.Errors;
using ErrorOr;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadApp.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthResult>> Handle(LoginQuery loginQuery, CancellationToken cancellationToken)
        {

            if (_userRepository.GetUserByEmail(loginQuery.Email) is not User user)
            {
                return UserErrors.FailedLogin;
            }

            if (user.Password != loginQuery.Password)
            {
                return UserErrors.FailedLogin;
            }

            string token = _jwtTokenGenerator.GenerateToken(user);

            await Task.CompletedTask;

            return new AuthResult(user, token);
        }
    }

}
