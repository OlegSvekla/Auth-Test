using IRLIX.Aggregator;
using IRLIX.Web.Startups;
using IRLIX.Web.Startups.Abstracts;
using Microsoft.AspNetCore.Builder;

namespace ShuttleX.Aggregator;

/// <summary>
/// Aggregator startup with basic to all microservices services
/// specific for ShuttleX apps
/// </summary>
public sealed class AggregatorStartup : ServiceStartup
{
    public override ServiceRegistrationOrderEnum ServiceRegistrationOrder
        => ServiceRegistrationOrderEnum.Higher;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchAggregator(builder.Configuration);

        return ValueTask.FromResult(services);
    }
}
