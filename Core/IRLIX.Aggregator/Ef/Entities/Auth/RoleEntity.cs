using IRLIX.Ef.Identity.Models;

namespace IRLIX.Aggregator.Ef.Entities.Auth;

public class RoleEntity : EfIdentityRoleEntity
{
    /// <summary>
    /// Role on users.
    /// </summary>
    public IList<UserRoleEntity> UserRoles { get; set; } = [];
}
