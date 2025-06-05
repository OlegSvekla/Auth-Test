using IRLIX.Core.Ef.Models.Enterfaces;
using IRLIX.Core.Ef.Models.Interfaces;

namespace IRLIX.Core.Ef.Models;

public abstract class EntityCreatedDate
    : EntityCreatedDate<Guid>,
    IEntity,
    IEntityCreatedDate;

public abstract class EntityCreatedDate<TId>
    : Entity<TId>,
    IEntityCreatedDate
    where TId : IEquatable<TId>
{
    public DateTimeOffset CreatedDate { get; set; }

    public Guid? CreatedByUserId { get; set; }
}