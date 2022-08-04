using BreadApp.Api.Contracts.Auth;
using BreadApp.Application.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BreadApp.Api.Controllers
{
    [Route("auth")]
    public class AuthController : BaseApiController
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            var authResult = _authService.Register(registerRequest.Name, registerRequest.Email, registerRequest.Password);

            return authResult.Match(
                        authResult => Ok(new AuthResponse(authResult.User.Id, authResult.User.Name, authResult.User.Email, authResult.Token)),
                        errors => Problem(errors)
                        );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest registerRequest)
        {
            var authResult = _authService.Login(registerRequest.Email, registerRequest.Password);

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