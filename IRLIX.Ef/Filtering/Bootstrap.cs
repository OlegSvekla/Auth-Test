namespace IRLIX.Ef.Filtering;

public static class Bootstrap
{
    public static IServiceCollection AddBatchEfFiltering(
        this IServiceCollection services)
    {
        services.AddScoped<IFilterExpressionByOperatorProvider, FilterExpressionByOperatorProvider>();
        services.AddScoped(typeof(IFilterStringToExpressionMapper<>), typeof(FilterStringToExpressionMapper<>));
        return services;
    }
}
