using IRLIX.Core.Ef.Models.Enterfaces;
using IRLIX.Core.Ef.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IRLIX.Core.Identity.Models;

public class EfIdentityRoleEntity
    : IdentityRole<Guid>,
    IEntity,
    IEntityCreatedUpdatedDates
{
    public DateTimeOffset CreatedDate { get; set; } = default!;

    [ProtectedPersonalData]
    public Guid? CreatedByUserId { get; set; }

    public DateTimeOffset UpdatedDate { get; set; } = default!;

    [ProtectedPersonalData]
    public Guid? UpdatedByUserId { get; set; }
}
