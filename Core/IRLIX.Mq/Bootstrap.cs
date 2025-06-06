using IRLIX.Mq.Assemblies;

namespace IRLIX.Mq;

public static class Bootstrap
{
    public static IServiceCollection AddBatchMq(this IServiceCollection services)
    {
        services.AddBatchMqAssemblies();

        return services;
    }
}
