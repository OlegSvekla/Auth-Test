using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.WebApis;

/// <summary>
/// Cookie policy.
/// It provides ability to control global characteristics of cookie processing
/// and hook into cookie processing handlers when cookies are appended or deleted.
/// It also conforms the app to the GDPR regulations.
/// See <see cref="https://learn.microsoft.com/en-us/aspnet/core/security/authentication/cookie"/>
/// See <see cref="https://learn.microsoft.com/en-us/aspnet/core/security/gdpr"/>
/// </summary>
public sealed class CookiePolicyStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.CookiePolicy;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchWebCookie(builder.Configuration);

        return ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.UseWebCookie();

        return ValueTask.FromResult(app);
    }
}
