using IRLIX.Core.Time;
using IRLIX.Ef.Models.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IRLIX.Ef.Setup.Soft.Cud;

public class SoftUpdateUpdater(
    IDateTimeProvider dateTimeProvider
    ) : ISoftPropertyUpdater
{
    public ValueTask UpdateAsync(EntityEntry entityEntry)
    {
        if (entityEntry.Entity is IEntityCreatedUpdatedDates entity)
        {
            entity.UpdatedDate = dateTimeProvider.UtcNow();
        }

        return ValueTask.CompletedTask;
    }
}
