namespace IRLIX.Di.DependencyResolvers;

public interface IServiceScopeDependencyResolver
    : IDependencyResolver
{
}

public sealed class ServiceScopeDependencyResolver(
    IServiceScopeFactory serviceScopeFactory
    ) : DependencyResolver,
        IServiceScopeDependencyResolver
{
    public override T Resolve<T>()
    {
        //TODO: Check if using losing scope and service become independent or null
        using var scope = serviceScopeFactory.CreateScope();
        return scope.ServiceProvider.GetRequiredService<T>();
    }

    public override object Resolve(
        Type type)
    {
        //TODO: Check if using losing scope and service become independent or null
        using var scope = serviceScopeFactory.CreateScope();
        return scope.ServiceProvider.GetRequiredService(type);
    }
}
