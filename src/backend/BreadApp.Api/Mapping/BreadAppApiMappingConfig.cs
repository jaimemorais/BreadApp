using BreadApp.Api.Contracts.Auth;
using BreadApp.Api.Contracts.Bread;
using BreadApp.Application.Auth;
using BreadApp.Application.Auth.Commands.Register;
using BreadApp.Application.Auth.Queries.Login;
using BreadApp.Application.Bread.Commands;
using BreadApp.Application.Bread.Queries;
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
            config.NewConfig<CreateBreadRequest, CreateBreadCommand>();

            config.NewConfig<GetBreadRequest, GetBreadQuery>();
            //.Map(dest => dest.Id, src => src.Id);

        }
    }
}
