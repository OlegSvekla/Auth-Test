using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.IpMappings;

/// <summary>
/// GeoLocationDb ip mapping services.
/// 
/// Require AppSettings section:
/// {
///     ...,
///     "IpMapping": {
///         ...,
///         "GeoLocationDb": {
///             "Host": "string"
///         },
///         ...
///     },
///     ...
/// }
/// </summary>
public sealed class IpMappingGeoLocationDbStartup : ServiceStartup
{
    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchIpMappingGeoLocationDb(builder.Configuration);

        return ValueTask.FromResult(services);
    }
}
