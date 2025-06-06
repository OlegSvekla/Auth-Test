using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.WebApis;

/// <summary>
/// Long polling.
/// AppSettings section:
/// Web: {
///     LongPolling: {
///         MaxHttpConnectionTimeSec: 30,
///         DelayAfterExecutionMilliseconds: 50
///     }
/// }
/// </summary>
public class LongPollingStartup : ServiceStartup
{
    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchLongPolling(builder.Configuration);
        return ValueTask.FromResult(services);
    }
}
