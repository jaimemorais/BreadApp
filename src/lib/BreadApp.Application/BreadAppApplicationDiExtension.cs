using BreadApp.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BreadApp.Application
{
    public static class BreadAppApplicationDiExtension
    {
        public static IServiceCollection AddBreadAppApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(x => x.AsScoped(), typeof(BreadAppApplicationDiExtension).Assembly);


            // Register all AbstractValidator(s) in this assembly
            services.AddValidatorsFromAssembly(typeof(BreadAppApplicationDiExtension).Assembly);

            // Register MediatR pipeline behavior when executing a handler, to execute the Command/Query Validator if it exists
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(BreadAppValidationBehavior<,>));

            return services;
        }
    }
}
