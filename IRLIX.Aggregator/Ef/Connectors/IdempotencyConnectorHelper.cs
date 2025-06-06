using Microsoft.EntityFrameworkCore;
using IRLIX.Aggregator.Ef.Entities.PaySys.Common;

namespace IRLIX.Aggregator.Ef.Connectors;

public static class IdempotencyConnectorHelper
{
    public static ValueTask ConnectIdempotencyAsync(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdempotencyEntity>()
            .UseTpcMappingStrategy();
        return ValueTask.CompletedTask;
    }
}
