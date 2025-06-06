using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IRLIX.Ef.Setup.Soft.Cud;

public interface ISoftPropertyUpdater
{
    ValueTask UpdateAsync(EntityEntry entityEntry);
}