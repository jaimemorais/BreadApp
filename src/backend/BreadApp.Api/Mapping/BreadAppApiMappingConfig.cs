using BreadApp.Api.Contracts.Auth;
using BreadApp.Api.Contracts.BreadDone;
using BreadApp.Api.Contracts.Image;
using BreadApp.Api.Contracts.Recipe;
using BreadApp.Application.Auth;
using BreadApp.Application.Auth.Commands;
using BreadApp.Application.Auth.Queries;
using BreadApp.Application.BreadDone.Commands;
using BreadApp.Application.BreadDone.Queries;
using BreadApp.Application.Image.Commands;
using BreadApp.Application.Recipe.Commands;
using BreadApp.Application.Recipe.Queries;
using BreadApp.Domain.Entities;
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
            config.NewConfig<BreadDone, BreadDoneResponse>()
                .Map(dest => dest.RecipeId, src => src.Recipe.Id)
                .Map(dest => dest.RecipeName, src => src.Recipe.Name);


            // Recipe
            config.NewConfig<AddRecipeRequest, AddRecipeCommand>();
            config.NewConfig<GetRecipeRequest, GetRecipeQuery>();
            config.NewConfig<PublishRecipeRequest, PublishRecipeCommand>();


            // Image
            config.NewConfig<UploadImageRequest, UploadImageCommand>();

            TypeAdapterConfig<IFormFile, IFormFile>.ForType()
                .MapWith(src => src);
        }
    }
}
