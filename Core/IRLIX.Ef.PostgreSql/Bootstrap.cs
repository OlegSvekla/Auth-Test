using IRLIX.Di.Configs;
using IRLIX.Ef.Configs;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace IRLIX.Ef.PostgreSql;

public static class Bootstrap
{
    public static IServiceCollection AddPostgreSqlEfConnection<TEfContext>(
        this IServiceCollection services,
        IConfiguration config)
        where TEfContext : DbContext, IEfContext
    {
        var dbConfig = config.Extract<DbConfig>(Consts.DbConfigSectionKey);

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(dbConfig.ConnectionString);
        dataSourceBuilder.EnableDynamicJson();
        dataSourceBuilder.UseJsonNet();
        var dataSource = dataSourceBuilder.Build();

        services.AddDbContext<IEfContext, TEfContext>(
            optionsAction: options => options
                .UseNpgsql(
                    dataSource: dataSource,
                    npgsqlOptionsAction: sqlOption => sqlOption
                        .EnableRetryOnFailure())
                .EnableSensitiveDataLogging());
        return services;
    }
}
