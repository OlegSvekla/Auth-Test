namespace IRLIX.Core.Hashes;

public static class Bootstrap
{
    public static IServiceCollection AddBatchHash(
        this IServiceCollection services)
    {
        services.AddSingleton<IHashClient, Sha256HashClient>();

        return services;
    }
}
