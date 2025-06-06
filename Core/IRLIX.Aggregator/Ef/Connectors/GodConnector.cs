using IRLIX.Ef.Setup;
using Microsoft.EntityFrameworkCore;

namespace IRLIX.Aggregator.Ef.Connectors;

public interface IGodConnector : IDbConnector;

public class GodConnector : DbConnector, IGodConnector
{
    public override async ValueTask ConnectAsync(ModelBuilder modelBuilder)
    {
        await base.ConnectAsync(modelBuilder);

        await modelBuilder.ConnectUserAsync();
        //await modelBuilder.ConnectIdempotencyAsync();
        //await modelBuilder.ConnectSagaPaymentAsync();
    }
}
