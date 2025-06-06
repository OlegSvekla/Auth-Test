using IRLIX.IpMapping.IpApi.Configs;
using Microsoft.Extensions.Options;

namespace IRLIX.IpMapping.IpApi.Providers;

public interface IIpApiConfigProvider
{
    string GetHost();
}

public class IpApiConfigProvider(
    IOptions<IpApiConfig> options
    ) : IIpApiConfigProvider
{
    private readonly IpApiConfig config = options.Value;

    public string GetHost()
        => config.Host;
}
