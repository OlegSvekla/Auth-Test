using IRLIX.IpMapping.IpApi.Configs;
using IRLIX.IpMapping.IpApi.Mappers;
using IRLIX.IpMapping.IpApi.Providers;

namespace IRLIX.IpMapping.IpApi;

public static class Bootstrap
{
    public static IServiceCollection AddBatchIpMappingIpApi(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddAppSettingsIpMappingIpApi(config);
        services.AddCoreIpMappingIpApi();

        return services;
    }

    public static IServiceCollection AddCoreIpMappingIpApi(
        this IServiceCollection services)
    {
        services.AddSingleton<IIpApiRsToFoundLocationMapper, IpApiRsToFoundLocationMapper>();
        services.AddScoped<ILocationByIpSearcher, IpApiSearcher>();
        services.AddScoped<IIpApiSearcher, IpApiSearcher>();

        return services;
    }

    public static IServiceCollection AddAppSettingsIpMappingIpApi(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.Configure<IpApiConfig>(config.GetSection(Consts.IpMappingIpApiConfigSectionKey));
        services.AddSingleton<IIpApiConfigProvider, IpApiConfigProvider>();

        return services;
    }
}
