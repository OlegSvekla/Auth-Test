using IRLIX.Core.Connectors;
using IRLIX.Core.Ef;
using IRLIX.Core.Ef.Setup;
using IRLIX.Core.Ef.Setup.Soft;
using IRLIX.Core.Entities;
using IRLIX.Core.Identity;
using Microsoft.EntityFrameworkCore;

namespace IRLIX.Repository;

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
