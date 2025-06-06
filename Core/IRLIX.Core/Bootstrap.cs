using IRLIX.Core.Microservice;
using IRLIX.Core.Serializers;
using IRLIX.Core.Time;
using IRLIX.Core.Hashes;
using System.Text;

namespace IRLIX.Core;

public static class Bootstrap
{
    /// <summary>
    /// Add batch Core services.
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
    public static IServiceCollection AddBatchCore(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddBatchHash();
        services.AddBatchMicroserviceData(config);
        services.AddBatchSerializers();
        services.AddBatchTime();

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        return services;
    }
}
