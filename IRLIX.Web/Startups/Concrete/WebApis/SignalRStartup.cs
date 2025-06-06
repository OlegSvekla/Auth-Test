using ShuttleX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.WebApis;

public sealed class SignalRStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.Endpoint;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder appBuilder)
    {
        services.AddSignalR();

        return ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
        //TODO: flexible way of registering hubs and setup
        //app.MapHub<NotificationHub>(NotificationHub.NotificationUrl);
        => ValueTask.FromResult(app);
}
