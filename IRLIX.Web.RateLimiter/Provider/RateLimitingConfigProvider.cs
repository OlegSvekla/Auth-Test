using IRLIX.Web.RateLimiter.Config;
using Microsoft.Extensions.Options;

namespace IRLIX.Web.RateLimiter.Provider;

public interface IRateLimitingConfigProvider
{
    int? GetMaxRequestsCount();

    int? GetIntervalSec();
}

public sealed class RateLimitingConfigProvider(
    IOptions<RateLimitingConfig> options
) : IRateLimitingConfigProvider
{
    private readonly RateLimitingConfig config = options.Value;

    public int? GetMaxRequestsCount()
        => config.MaxRequestsCount;

    public int? GetIntervalSec()
        => config.IntervalSec;
}
