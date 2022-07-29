using BreadApp.Application.Services.Auth;

namespace BreadApp.Api.Endpoints.Auth
{
    public class LoginEndpoint
    {
        private readonly IAuthService _authService;

        public LoginEndpoint(IAuthService authService)
        {
            _authService = authService;
        }

        public IResult Execute(LoginRequest loginRequest)
        {
            var authResult = _authService.Login(loginRequest.Email, loginRequest.Password);

            var response = new AuthResponse(authResult.User.Id, authResult.User.Name, authResult.User.Email, authResult.Token);

            return Results.Ok(response);
        }


    }



}
