using IRLIX.L11n;
using Microsoft.Extensions.DependencyInjection;

namespace IRLIX.BL.Resources;

public static class Bootstrap
{
    public static IServiceCollection AddBatchBLResources(
        this IServiceCollection services)
    {
        services.AddScoped<IResourceProvider, ResourceProvider>();

        return services;
    }
}
