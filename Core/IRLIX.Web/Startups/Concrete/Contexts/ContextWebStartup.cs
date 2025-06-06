using IRLIX.Context.Web;
using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.Contexts;

/// <summary>
/// Context services for web
/// </summary>
public sealed class ContextWebStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.Asap;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchContextWeb();

        return ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.UseBatchContextWeb();

        return ValueTask.FromResult(app);
    }
}
