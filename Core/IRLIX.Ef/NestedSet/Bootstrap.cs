namespace IRLIX.Ef.NestedSet;

public static class Bootstrap
{
    public static IServiceCollection AddBatchEfNestedSet(
        this IServiceCollection services)
    {
        services.AddScoped(typeof(INestedSetConverter<,,>), typeof(NestedSetConverter<,,>));
        return services;
    }
}
