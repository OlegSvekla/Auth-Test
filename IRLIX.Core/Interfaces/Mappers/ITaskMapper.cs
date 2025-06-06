namespace IRLIX.Core.Interfaces.Mappers;

public interface ITaskMapper<TInput, TOutput>
{
    Task<TOutput> MapAsync(TInput input, CancellationToken ct);
}
