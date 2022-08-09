using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BreadApp.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBreadAppApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(BreadApp.Application.ServiceRegistration).Assembly);

            return services;
        }
    }
}
