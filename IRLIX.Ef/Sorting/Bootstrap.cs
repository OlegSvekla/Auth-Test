namespace IRLIX.Ef.Sorting;

public static class Bootstrap
{
    public static IServiceCollection AddBatchEfSorting(
        this IServiceCollection services)
    {
        services.AddScoped(typeof(ISortingOrderedQueryableByOperatorProvider<>), typeof(SortingOrderedQueryableByOperatorProvider<>));
        services.AddScoped(typeof(ISortingQueryableByOperatorProvider<>), typeof(SortingQueryableByOperatorProvider<>));
        services.AddScoped(typeof(ISortingStringToExpressionMapper<>), typeof(SortingStringToExpressionMapper<>));
        return services;
    }
}
