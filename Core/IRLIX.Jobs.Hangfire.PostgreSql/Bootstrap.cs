using Microsoft.Extensions.DependencyInjection;

namespace IRLIX.Jobs.Hangfire.PostgreSql;

public static class Bootstrap
{
    public static IServiceCollection AddBatchJobsHangfirePostgreSql(
        this IServiceCollection services)
    {
        services.AddSingleton<IDbConnectionProvider, PostgreSqlDbConnectionProvider>();
        return services;
    }
}
