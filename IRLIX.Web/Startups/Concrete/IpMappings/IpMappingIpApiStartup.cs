using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.IpMappings;

/// <summary>
/// IpApi ip mapping services.
/// 
/// Require AppSettings section:
/// {
///     ...,
///     "IpMapping": {
///         ...,
///         "IpApi": {
///             "Host": "string"
///         },
///         ...
///     },
///     ...
/// }
/// </summary>
public sealed class IpMappingIpApiStartup : ServiceStartup
{
    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchIpMappingIpApi(builder.Configuration);

        return ValueTask.FromResult(services);
    }
}
