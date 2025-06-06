using ShuttleX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.WebApis;

/// <summary>
/// Static files.
/// Allow to operate with static files.
/// See <see cref="https://learn.microsoft.com/en-us/aspnet/core/fundamentals/static-files"/>
/// </summary>
public sealed class StaticFilesStartup : AppStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.StaticFiles;

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.UseStaticFiles();

        return ValueTask.FromResult(app);
    }
}
