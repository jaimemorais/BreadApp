using Mapster;
using MapsterMapper;
using System.Reflection;

namespace BreadApp.Api.Mapping
{
    public static class MappingDiExtension
    {
        public static IServiceCollection AddBreadAppObjectMappings(this IServiceCollection services)
        {
            var mapsterConfig = TypeAdapterConfig.GlobalSettings;

            mapsterConfig.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(mapsterConfig);

            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
