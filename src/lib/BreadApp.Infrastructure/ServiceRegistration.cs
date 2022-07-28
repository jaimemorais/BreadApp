using BreadApp.Application.Interfaces.Auth;
using BreadApp.Infrastructure.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BreadApp.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBreadAppInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));


            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();


            return services;
        }
    }
}
