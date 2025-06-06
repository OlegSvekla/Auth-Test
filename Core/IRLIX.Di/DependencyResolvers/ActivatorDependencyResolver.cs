using IRLIX.Di.Exceptions;

namespace IRLIX.Di.DependencyResolvers;

public interface IActivatorDependencyResolver
    : IDependencyResolver
{
}

public sealed class ActivatorDependencyResolver
    : DependencyResolver,
        IActivatorDependencyResolver
{
    public override T Resolve<T>()
        => Activator.CreateInstance<T>();

    public override object Resolve(
        Type type)
        => Activator.CreateInstance(type)
            ?? throw new ActivatorCreatedNullException(type);
}
