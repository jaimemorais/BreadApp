using BreadApp.Api.Contracts.Auth;
using BreadApp.Api.Contracts.BreadDone;
using BreadApp.Api.Contracts.Recipe;
using BreadApp.Application.Auth;
using BreadApp.Application.Auth.Commands.Register;
using BreadApp.Application.Auth.Queries.Login;
using BreadApp.Application.BreadDone.Commands;
using BreadApp.Application.BreadDone.Queries;
using BreadApp.Application.Recipe.Commands;
using BreadApp.Application.Recipe.Queries;
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


            // Bread Done
            config.NewConfig<AddBreadDoneRequest, AddBreadDoneCommand>();

            config.NewConfig<GetBreadDoneRequest, GetBreadDoneQuery>();

            // Recipe
            config.NewConfig<AddRecipeRequest, AddRecipeCommand>();

            config.NewConfig<GetRecipeRequest, GetRecipeQuery>();


        }
    }
}
