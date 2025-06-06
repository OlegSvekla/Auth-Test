using IRLIX.Ef.Models.Interfaces;
using IRLIX.Ef.Setup.Soft.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRLIX.Ef.Models;

[SoftDelete]
public abstract class Entity<TId>
    : IEntity<TId>
    where TId : IEquatable<TId>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual TId Id { get; set; } = default!;
}
