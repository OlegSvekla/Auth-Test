using Hangfire;
using Hangfire.PostgreSql;
using IRLIX.Jobs.Hangfire.Providers;

namespace IRLIX.Jobs.Hangfire.PostgreSql;

public sealed class PostgreSqlDbConnectionProvider(
    IHangfireConnectionStringProvider connectionStringProvider
    ) : IDbConnectionProvider
{
    public IGlobalConfiguration AddDbConnection(IGlobalConfiguration config)
        => config.UsePostgreSqlStorage(options
            => options.UseNpgsqlConnection(connectionStringProvider.GetConnectionString()));
}
