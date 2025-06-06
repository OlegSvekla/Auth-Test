using IRLIX.Aggregator.Ef.Configs;
using IRLIX.Aggregator.Ef.Connectors;
using IRLIX.Aggregator.Ef.Providers;
using IRLIX.Ef.Setup;
using Microsoft.Extensions.Configuration;

namespace IRLIX.Aggregator.Ef;

public static class Bootstrap
{
    public static IServiceCollection AddBatchAggregatorEf(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddAppSettingsAggregatorEf(config);
        services.AddCoreAggregatorEf();

        return services;
    }

    private static IServiceCollection AddCoreAggregatorEf(
        this IServiceCollection services)
    {
        services.AddScoped<GodConnector>();
        services.OverrideAndAddScoped<IDbConnector, GodConnector>(sp => sp.GetRequiredService<GodConnector>());
        services.AddScoped<IGodConnector, GodConnector>(sp => sp.GetRequiredService<GodConnector>());

        services.AddScoped<GodSeeder>();
        services.OverrideAndAddScoped<IDbSeeder, GodSeeder>(sp => sp.GetRequiredService<GodSeeder>());
        services.AddScoped<IGodSeeder, GodSeeder>(sp => sp.GetRequiredService<GodSeeder>());

        services.AddScoped<IGodContext, GodContext>(sp => sp.GetRequiredService<GodContext>());

        return services;
    }

    private static IServiceCollection AddAppSettingsAggregatorEf(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.Configure<AggregatorEfConfig>(config.GetSection(Consts.AggregatorEfConfigSectionKey));
        services.AddSingleton<IAggregatorEfConfigProvider, AggregatorEfConfigProvider>();

        return services;
    }
}
