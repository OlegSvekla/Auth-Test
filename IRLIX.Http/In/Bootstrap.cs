namespace IRLIX.Http.In;

public static class Bootstrap
{
    public static IServiceCollection AddBatchHttpIn(
        this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<IHttpContextDataSearcher, HttpContextDataSearcher>();

        return services;
    }
}
