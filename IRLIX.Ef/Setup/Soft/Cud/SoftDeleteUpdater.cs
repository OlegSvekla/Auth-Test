using IRLIX.Core.General;
using IRLIX.Core.Time;
using IRLIX.Ef.Configs;
using IRLIX.Ef.Setup.Soft.Attributes;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;

namespace IRLIX.Ef.Setup.Soft.Cud;

public class SoftDeleteUpdater(
    IDateTimeProvider dateTimeProvider,
    IOptions<DbConfig> config
    ) : ISoftPropertyUpdater
{
    public ValueTask UpdateAsync(EntityEntry entityEntry)
    {
        if (entityEntry.State != EntityState.Deleted)
        {
            return ValueTask.CompletedTask;
        }

        if (!config.Value.SetSoftDeleteByDefault)
        {
            return ValueTask.CompletedTask;
        }

        var entity = entityEntry.Entity;
 
        if (entity.HasAttribute<NonSoftDeleteAttribute>(inherit: true))
        {
            entityEntry.State = EntityState.Deleted;
        }
        else if (entity.HasAttribute<SoftDeleteAttribute>(inherit: true))
        {
            entityEntry.State = EntityState.Modified;
            entityEntry.CurrentValues["DeletedDate"] = dateTimeProvider.UtcNow();
        }
 
        return ValueTask.CompletedTask;
    }
}
