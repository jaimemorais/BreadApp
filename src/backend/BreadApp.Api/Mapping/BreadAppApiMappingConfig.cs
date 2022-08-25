using BreadApp.Api.Contracts.Auth;
using BreadApp.Api.Contracts.BreadDone;
using BreadApp.Application.Auth;
using BreadApp.Application.Auth.Commands.Register;
using BreadApp.Application.Auth.Queries.Login;
using BreadApp.Application.BreadDone.Commands;
using BreadApp.Application.BreadDone.Queries;
using Mapster;

namespace BreadApp.Api.Mapping
{
    public class BreadAppApiMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Auth
            config.NewConfig<RegisterRequest, RegisterUserCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthResult, AuthResponse>()
                .Map(dest => dest, src => src.User);


            // Bread
            config.NewConfig<AddBreadDoneRequest, AddRecipeCommand>();

            config.NewConfig<GetBreadDoneRequest, GetBreadDoneQuery>();


        }
    }
}
