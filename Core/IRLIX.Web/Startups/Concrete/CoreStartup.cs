using IRLIX.Core;
using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete;

/// <summary>
/// Core services.
/// 
/// Require AppSettings section:
/// {
///     ...,
///     "App": {
///         "Name": "string"
///     },
///     ...
/// }
/// </summary>
public sealed class CoreStartup : ServiceStartup
{
    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchCore(builder.Configuration);

        return ValueTask.FromResult(services);
    }
}
