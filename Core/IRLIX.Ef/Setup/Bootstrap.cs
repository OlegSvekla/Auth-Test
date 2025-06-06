using IRLIX.Ef.Setup.Soft;
using IRLIX.Ef.Setup.Soft.Cud;

namespace IRLIX.Ef.Setup;

public static class Bootstrap
{
    public static IServiceCollection AddBatchEfSetup(
        this IServiceCollection services)
    {
        services.AddScoped<ISoftPropertyUpdater, SoftCreateUpdater>();
        services.AddScoped<ISoftPropertyUpdater, SoftDeleteUpdater>();
        services.AddScoped<ISoftPropertyUpdater, SoftUpdateUpdater>();
        services.AddScoped<ISoftPropertiesCreator, SoftPropertiesCreator>();
        services.AddScoped<ISoftPropertiesUpdater, SoftPropertiesUpdater>();
        services.AddScoped<IDbConnector, DbConnector>();
        services.AddScoped<IDbSeeder, DbSeeder>();
        return services;
    }
}
