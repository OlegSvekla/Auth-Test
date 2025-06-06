using IRLIX.Web.Cors.Configs;
using Microsoft.Extensions.Options;

namespace IRLIX.Web.Cors.Providers;

public interface ICorsProvider
{
    CorsConfig GetConfigInfo();
}

public class CorsProvider(
    IOptions<CorsConfig> options
    ) : ICorsProvider
{
    private readonly CorsConfig config = options.Value;

    public CorsConfig GetConfigInfo()
        => config;
}
