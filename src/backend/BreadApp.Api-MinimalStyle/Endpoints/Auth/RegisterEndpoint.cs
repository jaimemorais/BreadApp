using BreadApp.Application.Auth.Commands.Register;
using MediatR;

namespace BreadApp.Api_MinimalStyle.Endpoints.Auth
{
    public class RegisterEndpoint
    {
        private readonly ISender _mediator;

        public RegisterEndpoint(ISender mediator)
        {
            _mediator = mediator;
        }


        public async Task<IResult> Execute(RegisterRequest registerRequest)
        {
            var command = new RegisterUserCommand(registerRequest.Name, registerRequest.Email, registerRequest.Password);

            var authResult = await _mediator.Send(command);

            return authResult.Match(
                        authResult => Results.Ok(new AuthResponse(authResult.User.Id, authResult.User.Name, authResult.User.Email, authResult.Token)),
                        errors => Results.BadRequest()
                        );
        }

    }



}
