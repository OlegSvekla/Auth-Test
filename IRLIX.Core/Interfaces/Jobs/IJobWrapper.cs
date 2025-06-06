namespace IRLIX.Core.Interfaces.Jobs;

public interface IJobWrapper
{
    Task RunInsideJobAsync(
        object? payload,
        CancellationToken ct);
}
