using BreadApp.Api.Contracts.Auth;
using BreadApp.Application.Authentication.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BreadApp.Api.Controllers
{
    [Route("auth")]
    public class AuthController : BaseApiController
    {

        private readonly ILogger<AuthController> _logger;
        private readonly ISender _mediator;

        public AuthController(ILogger<AuthController> logger, ISender mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var command = new RegisterCommand(registerRequest.Name, registerRequest.Email, registerRequest.Password);

            var authResult = await _mediator.Send(command);

            return authResult.Match(
                        authResult => Ok(new AuthResponse(authResult.User.Id, authResult.User.Name, authResult.User.Email, authResult.Token)),
                        errors => Problem(errors)
                        );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var query = new LoginQuery(loginRequest.Email, loginRequest.Password);
            var authResult = await _mediator.Send(query);

            if (authResult.IsError)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }

            return authResult.Match(
                        authResult => Ok(new AuthResponse(authResult.User.Id, authResult.User.Name, authResult.User.Email, authResult.Token)),
                        errors => Problem(errors)
                        );
        }


    }
}