using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.WebApis;

public sealed class ResponseHandlerStartup : AppStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.ResponseHandler;

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.UseResponseCaching();

        return ValueTask.FromResult(app);
    }
}
