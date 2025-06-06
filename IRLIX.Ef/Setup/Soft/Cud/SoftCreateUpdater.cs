using IRLIX.Core.Time;
using IRLIX.Ef.Models.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IRLIX.Ef.Setup.Soft.Cud;

public class SoftCreateUpdater(
    IDateTimeProvider dateTimeProvider
    ) : ISoftPropertyUpdater
{
    public ValueTask UpdateAsync(EntityEntry entityEntry)
    {
        if (entityEntry is { Entity: IEntityCreatedDate entity, State: EntityState.Added })
        {
            entity.CreatedDate = dateTimeProvider.UtcNow();
        }

        return ValueTask.CompletedTask;
    }
}
