using IRLIX.Core.Identity.Models;

namespace IRLIX.Core.Entities;

public class UserRoleEntity : EfIdentityUserRoleEntity
{
    public UserEntity User { get; set; } = default!;

    public RoleEntity Role { get; set; } = default!;
}
