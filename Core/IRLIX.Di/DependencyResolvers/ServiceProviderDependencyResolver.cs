namespace IRLIX.Di.DependencyResolvers;

public interface IServiceProviderDependencyResolver
    : IDependencyResolver
{
}

public sealed class ServiceProviderDependencyResolver(
    IServiceProvider serviceProvider
    ) : DependencyResolver,
        IServiceProviderDependencyResolver
{
    public override T Resolve<T>()
        => serviceProvider.GetRequiredService<T>();

    public override object Resolve(
        Type type)
        => serviceProvider.GetRequiredService(type);
}
