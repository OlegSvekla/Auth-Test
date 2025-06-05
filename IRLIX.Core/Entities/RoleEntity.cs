using IRLIX.Core.Identity.Models;

namespace IRLIX.Core.Entities;

public class RoleEntity : EfIdentityRoleEntity
{
    /// <summary>
    /// Role on users.
    /// </summary>
    public IList<UserRoleEntity> UserRoles { get; set; } = [];
}
