using IRLIX.Web.RateLimiter.Config;
using IRLIX.Web.RateLimiter.Provider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.RateLimiting;

namespace IRLIX.Web.RateLimiter;

public static class Bootstrap
{
    public static IServiceCollection AddBatchRateLimiter(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddCoreRateLimiter(configuration);
        services.AddAppSettingsRateLimiter(configuration);

        return services;
    }

    private static void AddCoreRateLimiter(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var rateLimiterConfig = GetRateLimitingConfig(configuration);
        services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            // Allows X requests in Y seconds for 1 ip address.
            // By default, 10 requests in 1 second.
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
                RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: context.Connection.RemoteIpAddress?.ToString(),
                    factory: _ => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = rateLimiterConfig.MaxRequestsCount,
                        Window = TimeSpan.FromSeconds(rateLimiterConfig.IntervalSec)
                    }
                )!
            );
        });
    }

    private static void AddAppSettingsRateLimiter(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<RateLimitingConfig>(configuration.GetSection(Consts.WebRateLimiterConfigSectionKey));
        services.AddSingleton<IRateLimitingConfigProvider, RateLimitingConfigProvider>();
    }

    private static RateLimitingConfig GetRateLimitingConfig(
        ConfigurationManager configuration)
    {
        var rateLimitingConfig = new RateLimitingConfig();
        configuration.GetSection(Consts.WebRateLimiterConfigSectionKey).Bind(rateLimitingConfig);

        return rateLimitingConfig;
    }
}
