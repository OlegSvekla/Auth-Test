using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.WebApis;

/// <summary>
/// MVC.
/// Adding routing for mvc project
/// </summary>
public sealed class MvcStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.Endpoint;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddControllersWithViews();

        return ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.MapDefaultControllerRoute();
        // The same what is above
        //app.MapControllerRoute(
        //    name: "default",
        //    pattern: "{controller=Home}/{action=Index}/{id?}");

        return ValueTask.FromResult(app);
    }
}
