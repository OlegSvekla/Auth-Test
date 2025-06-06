using IRLIX.Ef.Identity;
using IRLIX.Ef.Identity.Models;
using IRLIX.Web.Identity;
using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.Identities;

/// <summary>
/// Identity Web.
/// It attempts to authenticate the user before they're allowed access to secure resources
/// (Authentication) and authorizes a user to access secure resources (Authorization)
/// See <see cref="https://learn.microsoft.com/en-us/aspnet/core/security/authentication"/>
/// </summary>
public sealed class IdentityWebStartup<TEfContext, TUser, TRole, TUserRole>
    : BaseStartup
    where TEfContext : EfIdentityContextBase<TUser, TRole, TUserRole>
    where TUser : EfIdentityUserEntity
    where TRole : EfIdentityRoleEntity
    where TUserRole : EfIdentityUserRoleEntity
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.Auth;
    public override ServiceRegistrationOrderEnum ServiceRegistrationOrder
        => ServiceRegistrationOrderEnum.Lower;

    public override async ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchWebIdentity<TEfContext, TUser, TRole, TUserRole>(builder.Configuration);

        return await ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.UseWebIdentity<TUser>();

        return ValueTask.FromResult(app);
    }
}
