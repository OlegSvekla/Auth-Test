using IRLIX.Ef.Models.Interfaces;

namespace IRLIX.Ef.Models;

public abstract class EntityCreatedUpdatedDates
    : EntityCreatedUpdatedDates<Guid>,
    IEntity,
    IEntityCreatedUpdatedDates;
