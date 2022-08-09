using BreadApp.Application.Authentication.Commands.Register;
using MediatR;

namespace BreadApp.Api.Endpoints.Auth
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
            var command = new RegisterCommand(registerRequest.Name, registerRequest.Email, registerRequest.Password);

            var authResult = await _mediator.Send(command);

            return authResult.Match(
                        authResult => Results.Ok(new AuthResponse(authResult.User.Id, authResult.User.Name, authResult.User.Email, authResult.Token)),
                        errors => Results.BadRequest()
                        );
        }

    }



}
