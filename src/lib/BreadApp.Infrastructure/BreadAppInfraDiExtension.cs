using BreadApp.Application.Common.Interfaces.Auth;
using BreadApp.Application.Common.Interfaces.Email;
using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Application.Common.Interfaces.Storage;
using BreadApp.Infrastructure.Auth;
using BreadApp.Infrastructure.Email;
using BreadApp.Infrastructure.Persistence.InMemory;
using BreadApp.Infrastructure.Storage;
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

            services.AddScoped<IImageStorageService, ImageAzureBlobStorageService>();

            services.AddTransient<IEmailSenderService, SendgridMailService>();


            return services;
        }
    }
}
