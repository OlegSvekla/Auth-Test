using IRLIX.Web.Startups.Abstracts;
using IRLIX.Web.ExceptionHandling;

namespace IRLIX.Web.Startups.Concrete.WebApis;

public sealed class ExceptionHandlerStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.ExceptionHandler;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchWebExceptionHandling();
        return ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        return ValueTask.FromResult(app);
    }
}
