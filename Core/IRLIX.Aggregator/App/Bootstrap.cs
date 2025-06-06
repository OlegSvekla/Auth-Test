using IRLIX.Core.Interfaces.App;

namespace IRLIX.Aggregator.App;

public static class Bootstrap
{
    public static IServiceCollection AddBatchAggregatorApp(
        this IServiceCollection services)
    {
        services.AddSingleton<IAppDataProvider, AppDataProvider>();
        return services;
    }
}
