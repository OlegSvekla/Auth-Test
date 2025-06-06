using IRLIX.Context.Web.Identity;
using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.Contexts;

/// <summary>
/// Context services for web
/// </summary>
public sealed class ContextWebIdentityStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.PreEndpoint;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchContextWebIdentity();

        return ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.UseBatchContextWebIdentity();

        return ValueTask.FromResult(app);
    }
}
