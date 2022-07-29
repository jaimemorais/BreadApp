using BreadApp.Application.Services.Auth;

namespace BreadApp.Api.Endpoints.Auth
{
    public class RegisterEndpoint
    {
        private readonly IAuthService _authService;

        public RegisterEndpoint(IAuthService authService)
        {
            _authService = authService;
        }

        public IResult Execute(RegisterRequest registerRequest)
        {
            var authResult = _authService.Register(registerRequest.Name, registerRequest.Email, registerRequest.Password);

            var response = new AuthResponse(authResult.User.Id, authResult.User.Name, authResult.User.Email, authResult.Token);

            return Results.Ok(response);
        }

    }



}
