using IRLIX.Ef.Configs;
using IRLIX.Ef.Filtering;
using IRLIX.Ef.NestedSet;
using IRLIX.Ef.Providers;
using IRLIX.Ef.Repositories;
using IRLIX.Ef.Setup;
using IRLIX.Ef.Sorting;

namespace IRLIX.Ef;

public static class Bootstrap
{
    public static IServiceCollection AddBatchEf(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddAppSettingsEf(config);
        services.AddCoreEf();

        return services;
    }

    public static IServiceCollection AddCoreEf(
        this IServiceCollection services)
    {
        services.AddBatchEfFiltering();
        services.AddBatchEfNestedSet();
        services.AddBatchEfRepositories();
        services.AddBatchEfSetup();
        services.AddBatchEfSorting();

        return services;
    }

    public static IServiceCollection AddAppSettingsEf(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.Configure<DbConfig>(config.GetSection(Consts.DbConfigSectionKey));
        services.AddSingleton<IDbConfigProvider, DbConfigProvider>();

        return services;
    }

    public static async ValueTask UseEfAsync(
        this IServiceProvider sp,
        CancellationToken ct)
    {
        var dbContext = sp.GetRequiredService<IEfContext>();
        await dbContext.InitAsync(ct);
    }
}
