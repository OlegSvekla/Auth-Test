using IRLIX.Http.Out;
using IRLIX.Http.Polly.Clients;
using IRLIX.Http.Polly.Clients.Policies;
using IRLIX.Http.Polly.Configs;
using IRLIX.Http.Polly.Providers;

namespace IRLIX.Http.Polly;

public static class Bootstrap
{
    public static IServiceCollection AddBatchHttpPolly(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddAppSettingsHttpPolly(config);
        services.AddCoreHttpPolly();

        return services;
    }

    public static IServiceCollection AddCoreHttpPolly(
        this IServiceCollection services)
    {
        services.AddHttpClient();

        services.AddScoped<IHttpSender, PollySender>();
        services.AddSingleton<HttpOneRqTimeoutPolicy>();
        services.AddSingleton<IPolicySetup, HttpOneRqTimeoutPolicy>(sp => sp.GetRequiredService<HttpOneRqTimeoutPolicy>());
        services.AddSingleton<IHttpOneRqTimeoutPolicy, HttpOneRqTimeoutPolicy>(sp => sp.GetRequiredService<HttpOneRqTimeoutPolicy>());
        services.AddSingleton<HttpRateLimiterPolicy>();
        services.AddSingleton<IPolicySetup, HttpRateLimiterPolicy>(sp => sp.GetRequiredService<HttpRateLimiterPolicy>());
        services.AddSingleton<IHttpRateLimiterPolicy, HttpRateLimiterPolicy>(sp => sp.GetRequiredService<HttpRateLimiterPolicy>());
        services.AddSingleton<HttpRetryPolicy>();
        services.AddSingleton<IPolicySetup, HttpRetryPolicy>(sp => sp.GetRequiredService<HttpRetryPolicy>());
        services.AddSingleton<IHttpRetryPolicy, HttpRetryPolicy>(sp => sp.GetRequiredService<HttpRetryPolicy>());
        services.AddScoped<IPollyClient, PollyClient>();

        return services;
    }

    public static IServiceCollection AddAppSettingsHttpPolly(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.Configure<HttpConfig>(config.GetSection(Consts.HttpConfigSectionKey));
        services.AddSingleton<IHttpConfigProvider, HttpConfigProvider>();

        return services;
    }
}
