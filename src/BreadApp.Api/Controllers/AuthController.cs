using BreadApp.Api.Contracts.Auth;
using BreadApp.Application.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BreadApp.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
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

            var response = new AuthResponse(authResult.User.Id, authResult.User.Name, authResult.User.Email, authResult.Token);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest registerRequest)
        {
            var authResult = _authService.Login(registerRequest.Email, registerRequest.Password);

            var response = new AuthResponse(authResult.User.Id, authResult.User.Name, authResult.User.Email, authResult.Token);

            return Ok(response);
        }
    }
}