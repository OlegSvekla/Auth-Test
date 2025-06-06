namespace IRLIX.Core.Interfaces.Mappers;

public interface IValueTaskMapper<TInput, TOutput>
{
    ValueTask<TOutput> MapAsync(TInput input, CancellationToken ct);
}
