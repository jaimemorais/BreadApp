using BreadApp.Application.Common.Interfaces.Auth;
using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Infrastructure.Auth;
using BreadApp.Infrastructure.Persistence.InMemory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BreadApp.Application
{
    public static class BreadAppInfraDiExtension
    {
        public static IServiceCollection AddBreadAppInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));


            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddScoped<IUserRepository, UserInMemoryRepository>();
            services.AddScoped<IBreadDoneRepository, BreadDoneInMemoryRepository>();
            services.AddScoped<IRecipeRepository, RecipeInMemoryRepository>();


            return services;
        }
    }
}
