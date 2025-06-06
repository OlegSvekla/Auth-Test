using IRLIX.Ef.Models.Interfaces;

namespace IRLIX.Ef.Models;

public abstract class Entity
    : Entity<Guid>,
    IEntity;
