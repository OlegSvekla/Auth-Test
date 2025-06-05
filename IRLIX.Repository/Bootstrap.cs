using IRLIX.Repository.Repositories;
using IRLIX.Repository.Repository.Interfaces.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IRLIX.Repository;

public static class Bootstrap
{
    public static IServiceCollection AddStartupRepository(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IUow, Uow>();
        services.AddDatabase(configuration);
        return services;
    }

    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<GodContext>(options =>
            options.UseNpgsql(configuration.GetSection("Database:ConnectionString").Value));
}
