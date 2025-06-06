using IRLIX.Ef.Identity.Models;
using IRLIX.Ef.Setup;
using IRLIX.Ef.Setup.Soft;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IRLIX.Ef.Identity;

public abstract class EfIdentityContextBase<TUser, TRole, TUserRole>(
    DbContextOptions options,
    IDbConnector connector,
    IDbSeeder seeder,
    ISoftPropertiesUpdater softUpdater,
    ISoftPropertiesCreator softCreator)
    : IdentityDbContext<TUser, TRole, Guid, IdentityUserClaim<Guid>, TUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>(options),
        IEfContext
    where TUser : EfIdentityUserEntity
    where TRole : EfIdentityRoleEntity
    where TUserRole : EfIdentityUserRoleEntity
{
    public async virtual ValueTask InitAsync(
        CancellationToken ct)
    {
        if (!Database.IsRelational())
        {
            return;
        }

        await Database.MigrateAsync(ct);
    }

    public override int SaveChanges()
    {
        softUpdater.OnSaveChangesAsync(ChangeTracker).AwaitSync();
        var result = base.SaveChanges();
        StopTracking();
        return result;
    }

    public override async Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess,
        CancellationToken ct = default)
    {
        await softUpdater.OnSaveChangesAsync(ChangeTracker);
        var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, ct);
        StopTracking();
        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        softCreator.OnModelCreating(builder).AwaitSync();
        connector.ConnectAsync(builder).AwaitSync();
        seeder.SeedAsync(builder).AwaitSync();
    }

    private void StopTracking()
        => ChangeTracker.Clear();
}
