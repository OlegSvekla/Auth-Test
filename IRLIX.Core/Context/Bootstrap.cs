namespace IRLIX.Core.Context;

public static class Bootstrap
{
    public static IServiceCollection AddBatchContext(this IServiceCollection services)
    {
        services.AddScoped<CallContextStorage>();
        services.AddScoped<ICallContextInitializer>(provider => provider.GetRequiredService<CallContextStorage>());
        services.AddScoped<ICallContextProvider>(provider => provider.GetRequiredService<CallContextStorage>());
        return services;
    }
}
