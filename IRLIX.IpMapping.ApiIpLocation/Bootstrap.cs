using IRLIX.IpMapping.ApiIpLocation.Configs;
using IRLIX.IpMapping.ApiIpLocation.Mappers;
using IRLIX.IpMapping.ApiIpLocation.Providers;

namespace IRLIX.IpMapping.ApiIpLocation;

public static class Bootstrap
{
    public static IServiceCollection AddBatchIpMappingApiIpLocation(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddAppSettingsIpMappingApiIpLocation(config);
        services.AddCoreIpMappingApiIpLocation();

        return services;
    }

    public static IServiceCollection AddCoreIpMappingApiIpLocation(
        this IServiceCollection services)
    {
        services.AddSingleton<IApiIpLocationRsToFoundLocationMapper, ApiIpLocationRsToFoundLocationMapper>();
        services.AddScoped<ILocationByIpSearcher, ApiIpLocationSearcher>();
        services.AddScoped<IApiIpLocationSearcher, ApiIpLocationSearcher>();

        return services;
    }

    public static IServiceCollection AddAppSettingsIpMappingApiIpLocation(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.Configure<ApiIpLocationConfig>(config.GetSection(Consts.IpMappingApiIpLocationConfigSectionKey));
        services.AddSingleton<IApiIpLocationConfigProvider, ApiIpLocationConfigProvider>();

        return services;
    }
}
