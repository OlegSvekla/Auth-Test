namespace IRLIX.Core.Time;

public static class Bootstrap
{
    public static IServiceCollection AddBatchTime(
        this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}
