using IRLIX.Context.Web.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace IRLIX.Context.Web;

public static class Bootstrap
{
    public static IServiceCollection AddBatchContextWeb(this IServiceCollection services)
    {
        services.AddScoped<CallContextInjectionMiddleware>();

        return services;
    }

    public static IApplicationBuilder UseBatchContextWeb(
        this IApplicationBuilder app)
    {
        app.UseMiddleware<CallContextInjectionMiddleware>();

        return app;
    }
}
