using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.WebApis;

/// <summary>
/// WebApi.
/// Adding routing for web api project
/// </summary>
public sealed class WebApiStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.Endpoint;
    public override ServiceRegistrationOrderEnum ServiceRegistrationOrder
        => ServiceRegistrationOrderEnum.Medium;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddEndpointsApiExplorer();
        services.AddControllers();

        return ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.MapControllers();

        return ValueTask.FromResult(app);
    }
}
