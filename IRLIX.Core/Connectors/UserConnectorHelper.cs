using IRLIX.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace IRLIX.Core.Connectors;

public static class UserConnectorHelper
{
    public static ValueTask ConnectUserAsync(
        this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRoleEntity>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRoleEntity>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

        modelBuilder.Entity<UserRoleEntity>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();

        return ValueTask.CompletedTask;
    }
}
