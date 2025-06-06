using IRLIX.Ef.Identity.Models;
using IRLIX.Web.Identity.Lockouts.Middlewares;

namespace IRLIX.Web.Identity.Lockouts;

public static class Bootstrap
{
    public static IServiceCollection AddBatchWebIdentityLockout<TUser>(
        this IServiceCollection services)
        where TUser : EfIdentityUserEntity
    {
        services.AddScoped<LockoutMiddleware<TUser>>();
        services.AddScoped<ILockoutClient, LockoutClient<TUser>>();

        return services;
    }

    public static IApplicationBuilder UseLockout<TUser>(
        this IApplicationBuilder app)
        where TUser : EfIdentityUserEntity
    {
        app.UseMiddleware<LockoutMiddleware<TUser>>();

        return app;
    }
}
