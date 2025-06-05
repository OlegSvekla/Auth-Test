using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IRLIX.Core.Ef.Setup.Soft.Cud;

public interface ISoftPropertyUpdater
{
    ValueTask UpdateAsync(EntityEntry entityEntry);
}
