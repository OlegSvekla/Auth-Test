using IRLIX.Web.Polling.Config;
using IRLIX.Web.Polling.Provider;
using IRLIX.Web.Polling.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IRLIX.Web.Polling;

public static class Bootstrap
{
    public static IServiceCollection AddBatchLongPolling(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ILongPollingService, LongPollingService>();

        services.AddSingleton<ILongPollingConfigProvider, LongPollingConfigProvider>();
        services.Configure<LongPollingConfig>(configuration.GetSection(Consts.WebLongPollingConfigSectionKey));

        return services;
    }
}
