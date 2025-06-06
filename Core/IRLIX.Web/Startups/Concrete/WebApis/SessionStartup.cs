using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.WebApis;

/// <summary>
/// Session.
/// Session state is an ASP.NET Core scenario for storage of user data while the user browses a web app.
/// See <see cref="https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state"/>
/// </summary>
public sealed class SessionStartup : AppStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.Session;

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.UseSession();

        return ValueTask.FromResult(app);
    }
}
