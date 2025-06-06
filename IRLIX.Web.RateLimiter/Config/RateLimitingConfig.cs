namespace IRLIX.Web.RateLimiter.Config;

public class RateLimitingConfig
{
    public int MaxRequestsCount { get; init; } = Consts.DefaultMaxRequestsCount;

    public int IntervalSec { get; init; } = Consts.DefaultIntervalSec;
}
