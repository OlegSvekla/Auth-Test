using IRLIX.Core.Microservice.Config;
using IRLIX.Core.Microservice.Providers;
using SIRLIXhuttleX.Core.Microservice;

namespace IRLIX.Core.Microservice;

public static class Bootstrap
{
    /// <summary>
    /// Add batch MicroserviceData services.
    /// 
    /// Require AppSettings section:
    /// {
    ///     ...,
    ///     "App": {
    ///         "Name": "string",
    ///         "Scope": "string"
    ///     },
    ///     ...
    /// }
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddBatchMicroserviceData(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddAppSettingsMicroserviceData(config);

        return services;
    }

    /// <summary>
    /// Add MicroserviceData services via AppSettings.
    /// 
    /// Require AppSettings section:
    /// {
    ///     ...,
    ///     "App": {
    ///         "Name": "string",
    ///         "Scope": "string"
    ///     },
    ///     ...
    /// }
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddAppSettingsMicroserviceData(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.Configure<MicroserviceConfig>(config.GetSection(Consts.MicroserviceConfigSectionKey));
        services.AddSingleton<IMicroserviceDataProvider, MicroserviceDataProvider>();
        
        return services;
    }
}
