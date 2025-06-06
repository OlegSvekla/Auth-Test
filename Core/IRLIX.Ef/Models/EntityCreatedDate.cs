using IRLIX.Ef.Models.Interfaces;

namespace IRLIX.Ef.Models;

public abstract class EntityCreatedDate
    : EntityCreatedDate<Guid>,
    IEntity,
    IEntityCreatedDate;
