using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BreadApp.Application
{
    public static class BreadAppApplicationDiExtension
    {
        public static IServiceCollection AddBreadAppApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(BreadAppApplicationDiExtension).Assembly);

            return services;
        }
    }
}
