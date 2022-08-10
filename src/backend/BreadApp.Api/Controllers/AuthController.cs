using BreadApp.Api.Contracts.Auth;
using BreadApp.Application.Authentication;
using BreadApp.Application.Authentication.Commands.Register;
using BreadApp.Application.Authentication.Queries.Login;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BreadApp.Api.Controllers
{
    [Route("auth")]
    public class AuthController : BaseApiController
    {

        private readonly ILogger<AuthController> _logger;
        private readonly ISender _mediator;
        private readonly IMapper _mapster;


        public AuthController(ILogger<AuthController> logger, ISender mediator, IMapper mapster)
        {
            _logger = logger;
            _mediator = mediator;
            _mapster = mapster;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var command = _mapster.Map<RegisterCommand>(registerRequest);

            ErrorOr<AuthResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                        authResult => Ok(_mapster.Map<AuthResponse>(authResult)),
                        errors => Problem(errors)
                        );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var query = _mapster.Map<LoginQuery>(loginRequest);
            var authResult = await _mediator.Send(query);

            if (authResult.IsError)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }

            return authResult.Match(
                        authResult => Ok(_mapster.Map<AuthResponse>(authResult)),
                        errors => Problem(errors)
                        );
        }


    }
}