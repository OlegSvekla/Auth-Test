using IRLIX.Ef.Identity.Models;

namespace IRLIX.Aggregator.Ef.Entities.Auth;

public class UserRoleEntity : EfIdentityUserRoleEntity
{
    public UserEntity User { get; set; } = default!;

    public RoleEntity Role { get; set; } = default!;
}
