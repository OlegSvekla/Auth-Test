using IRLIX.Aggregator.Ef.Connectors;
using IRLIX.Di.Helpers;
using IRLIX.Ef.Setup;
using Microsoft.Extensions.Configuration;

namespace IRLIX.Aggregator.Ef;

public static class Bootstrap
{
    public static IServiceCollection AddBatchAggregatorEf(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddCoreAggregatorEf();

        return services;
    }

    private static IServiceCollection AddCoreAggregatorEf(
        this IServiceCollection services)
    {
        services.AddScoped<GodConnector>();
        services.OverrideAndAddScoped<IDbConnector, GodConnector>(sp => sp.GetRequiredService<GodConnector>());
        services.AddScoped<IGodConnector, GodConnector>(sp => sp.GetRequiredService<GodConnector>());

        services.AddScoped<IGodContext, GodContext>(sp => sp.GetRequiredService<GodContext>());

        return services;
    }
}
