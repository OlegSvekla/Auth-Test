namespace IRLIX.Mq.Assemblies;

public static class Bootstrap
{
    public static IServiceCollection AddBatchMqAssemblies(
        this IServiceCollection services)
    {
        services.AddSingleton<ISolutionCommandTypeSearcher, SolutionMessageTypeSearcher>();
        services.AddSingleton<ISolutionEventTypeSearcher, SolutionMessageTypeSearcher>();
        services.AddSingleton<ISolutionQueryTypeSearcher, SolutionMessageTypeSearcher>();

        return services;
    }
}
