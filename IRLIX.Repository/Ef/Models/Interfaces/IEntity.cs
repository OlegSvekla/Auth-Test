namespace IRLIX.Repository.Ef.Models.Interfaces;

public interface IEntity<TId>
    where TId : IEquatable<TId>
{
    TId Id { get; set; }
}

public interface IEntity : IEntity<Guid>;
