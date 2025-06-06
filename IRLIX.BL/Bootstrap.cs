using IRLIX.Auth.Shared;
using IRLIX.BL.Otps;
using IRLIX.BL.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace IRLIX.BL;

public static class Bootstrap
{
    public static IServiceCollection AddBatchBL(
        this IServiceCollection services)
    {
        services.AddBatchBLOtps();
        services.AddBatchBLResources();
        services.AddBatchBLShared();

        return services;
    }
}
