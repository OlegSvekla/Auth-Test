using IRLIX.Aggregator.Ef.Entities.Auth;
using IRLIX.Aggregator.Ef.Providers;
using IRLIX.Aggregator.Ef.Roles;
using IRLIX.Ef.Setup;
using Microsoft.EntityFrameworkCore;

namespace IRLIX.Aggregator.Ef;

public interface IGodSeeder : IDbSeeder;

public class GodSeeder(
    IAggregatorEfConfigProvider configProvider
    ) : IGodSeeder
{
    public virtual ValueTask SeedAsync(ModelBuilder modelBuilder)
    {
        var adminRoleId = Guid.Parse(Consts.DefaultAdminGuid);
        var supportRoleId = Guid.Parse(Consts.DefaultSupportGuid);

        modelBuilder
            .Entity<RoleEntity>()
            .HasData(new RoleEntity
            {
                Id = adminRoleId,
                Name = RoleNames.Admin,
                NormalizedName = RoleNames.Admin.ToUpperInvariant()
            });

        modelBuilder
            .Entity<RoleEntity>()
            .HasData(new RoleEntity
            {
                Id = supportRoleId,
                Name = RoleNames.Support,
                NormalizedName = RoleNames.Support.ToUpperInvariant()
            });

        TryCreateAdminAcc(modelBuilder, adminRoleId, supportRoleId);

        return ValueTask.CompletedTask;
    }

    private void TryCreateAdminAcc(
        ModelBuilder modelBuilder,
        Guid adminRoleId,
        Guid supportRoleId)
    {
        var adminEmail = configProvider.FindDefaultAdminEmail();
        if (string.IsNullOrWhiteSpace(adminEmail))
        {
            return;
        }

        var adminId = Guid.Parse(Consts.DefaultAdminGuid);
        var adminUserName = Guid.Parse(Consts.DefaultAdminGuid).ToString();
        var securityStamp = Guid.Parse(Consts.DefaultAdminGuid).ToString();
        var concurrencyStamp = Guid.Parse(Consts.DefaultAdminGuid).ToString();

        var admin = new UserEntity
        {
            Id = adminId,
            UserName = adminUserName,
            NormalizedUserName = adminUserName.ToUpperInvariant(),
            SecurityStamp = securityStamp,
            ConcurrencyStamp = concurrencyStamp,
            PhoneNumber = string.Empty,
            PhoneNumberConfirmed = true,
            Email = adminEmail.ToLowerInvariant(),
            NormalizedEmail = adminEmail.ToUpperInvariant(),
            EmailConfirmed = true
        };

        var adminHardcodedCode = configProvider.FindDefaultAdminHardcodedCode();
        if (!string.IsNullOrWhiteSpace(adminHardcodedCode))
        {
            admin.HardcodedCode = adminHardcodedCode;
        }

        modelBuilder
            .Entity<UserEntity>()
            .HasData(admin);

        modelBuilder
            .Entity<UserRoleEntity>()
            .HasData(new UserRoleEntity
            {
                RoleId = adminRoleId,
                UserId = adminId
            });

        modelBuilder
            .Entity<UserRoleEntity>()
            .HasData(new UserRoleEntity
            {
                RoleId = supportRoleId,
                UserId = adminId
            });
    }
}
