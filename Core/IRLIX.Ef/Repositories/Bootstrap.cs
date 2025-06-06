namespace IRLIX.Ef.Repositories;

public static class Bootstrap
{
    public static IServiceCollection AddBatchEfRepositories(
        this IServiceCollection services)
    {
        services.AddScoped<IUow, Uow>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        return services;
    }
}
