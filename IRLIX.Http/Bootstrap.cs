using IRLIX.Http.In;
using IRLIX.Http.Out;

namespace IRLIX.Http;

public static class Bootstrap
{
    public static IServiceCollection AddBatchHttp(
        this IServiceCollection services)
    {
        services.AddBatchHttpIn();
        services.AddBatchHttpOut();

        return services;
    }
}
