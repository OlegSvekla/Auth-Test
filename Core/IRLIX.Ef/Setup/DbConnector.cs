namespace IRLIX.Ef.Setup;

public interface IDbConnector
{
    ValueTask ConnectAsync(ModelBuilder modelBuilder);
}

public class DbConnector : IDbConnector
{
    public virtual ValueTask ConnectAsync(ModelBuilder modelBuilder)
        => ValueTask.CompletedTask;
}
