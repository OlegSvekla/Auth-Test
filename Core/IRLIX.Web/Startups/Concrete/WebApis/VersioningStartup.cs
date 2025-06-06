using ShuttleX.Web.Startups.Abstracts;
using ShuttleX.Web.Versioning;

namespace IRLIX.Web.Startups.Concrete.WebApis;

/// <summary>
/// Microservice data.
/// Custom implementation to get basic information about executed microservice
/// </summary>
public sealed class VersioningStartup : ServiceStartup
{
    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchWebVersioning();

        return ValueTask.FromResult(services);
    }
}
