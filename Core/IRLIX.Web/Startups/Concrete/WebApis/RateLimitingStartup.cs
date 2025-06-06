using IRLIX.Web.RateLimiter;
using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.WebApis;

/// <summary>
/// Rate limiting.
/// Rate limiting is a strategy for limiting network traffic.
/// See <see cref="https://learn.microsoft.com/en-us/aspnet/core/performance/rate-limit"/>
/// 
/// AppSettings section:
/// Web: {
///     RateLimiter: {
///         MaxRequests: 10
///         IntervalSeconds: 1
///     }
/// }
/// </summary>
public sealed class RateLimitingStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.RateLimit;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchRateLimiter(builder.Configuration);

        return ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.UseRateLimiter();

        return ValueTask.FromResult(app);
    }
}
