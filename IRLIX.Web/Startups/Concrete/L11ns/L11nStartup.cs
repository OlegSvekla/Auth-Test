using IRLIX.L11n;
using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.L11ns;

/// <summary>
/// Localization.
/// </summary>
public sealed class L11nStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.L11n;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchWebL11n(builder.Configuration);

        return ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.UseWebL11n();

        return ValueTask.FromResult(app);
    }
}
