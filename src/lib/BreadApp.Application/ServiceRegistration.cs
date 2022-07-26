using BreadApp.Application.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace BreadApp.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBreadAppApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
