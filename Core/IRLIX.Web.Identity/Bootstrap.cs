using IRLIX.Ef.Identity;
using IRLIX.Ef.Identity.Models;
using IRLIX.Web.Identity.Lockouts;
using IRLIX.Web.Identity.Otps;
using IRLIX.Web.Identity.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace IRLIX.Web.Identity;

public static class Bootstrap
{
    public static IServiceCollection AddBatchWebIdentity<TEfContext, TUser, TRole, TUserRole>(
        this IServiceCollection services,
        IConfiguration config)
        where TEfContext : EfIdentityContextBase<TUser, TRole, TUserRole>
        where TUser : EfIdentityUserEntity
        where TRole : EfIdentityRoleEntity
        where TUserRole : EfIdentityUserRoleEntity
    {
        services
            .AddIdentity<TUser, TRole>()
            .AddEntityFrameworkStores<TEfContext>()
            .AddDefaultTokenProviders()
            .AddBatchWebIdentityOtps<TUser>();

        services.Configure<IdentityOptions>(options
            => options.Lockout.MaxFailedAccessAttempts = int.MaxValue);

        services.AddBatchWebIdentityLockout<TUser>();
        services.AddBatchWebIdentityTokens(config);

        services.AddScoped<IAuthUserManager<TUser>, AuthUserManager<TUser>>();

        return services;
    }

    public static IApplicationBuilder UseWebIdentity<TUser>(
        this IApplicationBuilder app)
        where TUser : EfIdentityUserEntity
    {
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseLockout<TUser>();

        return app;
    }
}
