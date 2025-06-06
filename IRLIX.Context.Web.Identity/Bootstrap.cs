using IRLIX.Context.Web.Identity.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace IRLIX.Context.Web.Identity;

public static class Bootstrap
{
    public static IServiceCollection AddBatchContextWebIdentity(this IServiceCollection services)
    {
        services.AddScoped<CallContextUserClaimsInjectionMiddleware>();

        return services;
    }

    public static IApplicationBuilder UseBatchContextWebIdentity(
        this IApplicationBuilder app)
    {
        app.UseMiddleware<CallContextUserClaimsInjectionMiddleware>();

        return app;
    }
}
