namespace IRLIX.Core.Ef.Models.Enterfaces;

public interface IEntity<TId>
    where TId : IEquatable<TId>
{
    TId Id { get; set; }
}

public interface IEntity : IEntity<Guid>;
