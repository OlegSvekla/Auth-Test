using IRLIX.Aggregator.Ef.Connectors;
using IRLIX.Aggregator.Ef.Entities.Auth;
using IRLIX.Ef;
using IRLIX.Ef.Identity;
using IRLIX.Ef.Setup;
using IRLIX.Ef.Setup.Soft;
using Microsoft.EntityFrameworkCore;

namespace IRLIX.Aggregator.Ef;

public interface IGodContext : IEfContext
{
    #region Auth

    DbSet<UserEntity> Users { get; }

    DbSet<RoleEntity> Roles { get; }

    DbSet<SignInAttemptEntity> SignInAttempts { get; }

    DbSet<SessionEntity> Sessions { get; }

    #endregion Auth
}

public class GodContext(
    DbContextOptions options,
    IGodConnector connector,
    IDbSeeder seeder,
    ISoftPropertiesUpdater softUpdater,
    ISoftPropertiesCreator softCreator
    ) : EfIdentityContextBase<UserEntity, RoleEntity, UserRoleEntity>(
        options,
        connector,
        seeder,
        softUpdater,
        softCreator),
    IGodContext
{
    #region Auth

    public DbSet<SignInAttemptEntity> SignInAttempts { get; set; } = default!;

    public DbSet<SessionEntity> Sessions { get; set; } = default!;

    #endregion Auth
}
