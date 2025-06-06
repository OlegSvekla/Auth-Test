using IRLIX.Ef.Setup.Soft.Cud;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IRLIX.Ef.Setup.Soft;

public interface ISoftPropertiesUpdater
{
    ValueTask OnSaveChangesAsync(
        ChangeTracker changeTracker);
}

public class SoftPropertiesUpdater(
    IEnumerable<ISoftPropertyUpdater> softUpdaters
    ) : ISoftPropertiesUpdater
{
    public async ValueTask OnSaveChangesAsync(
        ChangeTracker changeTracker)
    {
        foreach (var entityEntry in changeTracker.Entries())
        {
            foreach (var softUpdater in softUpdaters)
            {
                await softUpdater.UpdateAsync(entityEntry);
            }
        }
    }
}
