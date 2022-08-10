using BreadApp.Api.Contracts.Auth;
using BreadApp.Application.Authentication;
using BreadApp.Application.Authentication.Commands.Register;
using BreadApp.Application.Authentication.Queries.Login;
using Mapster;

namespace BreadApp.Api.Mapping
{
    public class AuthMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthResult, AuthResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
