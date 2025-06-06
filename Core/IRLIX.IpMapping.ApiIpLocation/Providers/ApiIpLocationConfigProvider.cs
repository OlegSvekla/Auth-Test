using IRLIX.IpMapping.ApiIpLocation.Configs;
using Microsoft.Extensions.Options;

namespace IRLIX.IpMapping.ApiIpLocation.Providers;

public interface IApiIpLocationConfigProvider
{
    string GetHost();
}

public class ApiIpLocationConfigProvider(
    IOptions<ApiIpLocationConfig> options
    ) : IApiIpLocationConfigProvider
{
    private readonly ApiIpLocationConfig config = options.Value;

    public string GetHost()
        => config.Host;
}
