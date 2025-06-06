using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.Mqs;

public class MqDistributedHttpStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.Endpoint;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchMqDistributedHttp(builder.Configuration);

        return ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.MapMqDistributedHttpEndpoints(app.Configuration);

        return ValueTask.FromResult(app);
    }
}
