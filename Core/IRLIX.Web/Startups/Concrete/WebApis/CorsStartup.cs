using ShuttleX.Web.Cors;
using ShuttleX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.WebApis;

/// <summary>
/// Cors.
/// Cross Origin Resource Sharing is necessary for browser security which prevents a web
/// page from making requests to a different domain than the one that served the web page.
/// See <see cref="https://learn.microsoft.com/en-us/aspnet/core/security/cors"/>
/// </summary>
public sealed class CorsStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.Cors;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchWebCors(builder.Configuration);

        return ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.UseWebCors();

        return ValueTask.FromResult(app);
    }
}
