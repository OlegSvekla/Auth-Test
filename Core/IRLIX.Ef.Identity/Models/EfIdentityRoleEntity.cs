using IRLIX.Ef.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IRLIX.Ef.Identity.Models;

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
