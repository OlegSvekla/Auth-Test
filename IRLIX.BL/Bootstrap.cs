using IRLIX.Auth.Shared;
using IRLIX.BL.Otps;
using IRLIX.BL.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace IRLIX.BL;

public static class Bootstrap
{
    public static IServiceCollection AddBatchAuth(
        this IServiceCollection services)
    {
        services.AddBatchAuthOtps();
        services.AddBatchAuthResources();
        services.AddBatchAuthShared();

        return services;
    }
}
