using IRLIX.Ef.Models.Interfaces;

namespace IRLIX.Ef.Models;

public abstract class EntityCreatedDate<TId>
    : Entity<TId>,
    IEntityCreatedDate
    where TId : IEquatable<TId>
{
    public DateTimeOffset CreatedDate { get; set; }

    public Guid? CreatedByUserId { get; set; }
}
