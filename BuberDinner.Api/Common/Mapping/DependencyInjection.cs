using System.Reflection;
using Mapster;
using MapsterMapper;

namespace BuberDinner.Api.Common.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var congif = TypeAdapterConfig.GlobalSettings;
        congif.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(congif);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}
