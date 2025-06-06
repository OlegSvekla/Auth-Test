using IRLIX.Aggregator.App;
using IRLIX.Aggregator.Ef;
using Microsoft.Extensions.Configuration;

namespace IRLIX.Aggregator;

public static class Bootstrap
{
    public static IServiceCollection AddBatchAggregator(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddBatchAggregatorApp();
        services.AddBatchAggregatorEf(config);
        services.AddBatchAggregatorSimulacrums();

        return services;
    }
}
