using IRLIX.Web.Startups.Abstracts;
using ShuttleX.IpMapping.ApiIpLocation;
using ShuttleX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.IpMappings;

/// <summary>
/// ApiIpLocation ip mapping services.
/// 
/// Require AppSettings section:
/// {
///     ...,
///     "IpMapping": {
///         ...,
///         "ApiIpLocation": {
///             "Host": "string"
///         },
///         ...
///     },
///     ...
/// }
/// </summary>
public sealed class IpMappingApiIpLocationStartup : ServiceStartup
{
    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchIpMappingApiIpLocation(builder.Configuration);

        return ValueTask.FromResult(services);
    }
}
