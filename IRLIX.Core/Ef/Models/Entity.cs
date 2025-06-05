using IRLIX.Core.Attributes;
using IRLIX.Core.Ef.Models.Enterfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRLIX.Core.Ef.Models;

[SoftDelete]
public abstract class Entity<TId>
    : IEntity<TId>
    where TId : IEquatable<TId>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual TId Id { get; set; } = default!;
}
