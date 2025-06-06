using IRLIX.Mq;
using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.Mqs;

/// <summary>
/// Message queue services.
/// </summary>
public sealed class MqStartup : ServiceStartup
{
    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchMq();
        return ValueTask.FromResult(services);
    }
}
