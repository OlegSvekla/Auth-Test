using IRLIX.Web.Startups;

namespace IRLIX.Web.Startups.Abstracts;

public interface IServiceStartup : IStartup
{
}

public abstract class ServiceStartup
    : BaseStartup,
    IServiceStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.Asap;

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
        => ValueTask.FromResult(app);
}
