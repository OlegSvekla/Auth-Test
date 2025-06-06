using IRLIX.Ef.Models.Interfaces;

namespace IRLIX.Ef.Models;

public abstract class EntityCreatedUpdatedDates<TId>
    : EntityCreatedDate<TId>,
    IEntityCreatedUpdatedDates
    where TId : IEquatable<TId>
{
    public DateTimeOffset UpdatedDate { get; set; }

    public Guid? UpdatedByUserId { get; set; }
}
