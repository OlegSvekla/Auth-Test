using IRLIX.Core.Ef.Models.Enterfaces;
using IRLIX.Core.Ef.Models.Interfaces;

namespace IRLIX.Core.Ef.Models;

public abstract class EntityCreatedUpdatedDates
    : EntityCreatedUpdatedDates<Guid>,
    IEntity,
    IEntityCreatedUpdatedDates;

public abstract class EntityCreatedUpdatedDates<TId>
    : EntityCreatedDate<TId>,
    IEntityCreatedUpdatedDates
    where TId : IEquatable<TId>
{
    public DateTimeOffset UpdatedDate { get; set; }

    public Guid? UpdatedByUserId { get; set; }
}