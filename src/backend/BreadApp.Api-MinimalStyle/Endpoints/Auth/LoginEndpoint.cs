using BreadApp.Application.Auth.Queries.Login;
using MediatR;

namespace BreadApp.Api_MinimalStyle.Endpoints.Auth
{
    public class LoginEndpoint
    {
        private readonly ISender _mediator;

        public LoginEndpoint(ISender mediator)
        {
            _mediator = mediator;
        }



        public async Task<IResult> Execute(LoginRequest loginRequest)
        {
            var query = new LoginQuery(loginRequest.Email, loginRequest.Password);
            var authResult = await _mediator.Send(query);

            if (authResult.IsError)
            {
                return Results.Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }

            return authResult.Match(
                        authResult => Results.Ok(new AuthResponse(authResult.User.Id, authResult.User.Name, authResult.User.Email, authResult.Token)),
                        errors => Results.Unauthorized()
                        );
        }


    }



}
