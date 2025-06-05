using IRLIX.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace IRLIX.Core.Connectors;

public static class IdempotencyConnectorHelper
{
    public static ValueTask ConnectIdempotencyAsync(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdempotencyEntity>()
            .UseTpcMappingStrategy();
        return ValueTask.CompletedTask;
    }
}
