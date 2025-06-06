using IRLIX.Mq.Messages;

namespace IRLIX.Mq.Buses;

public interface IQueryDispatcher
{
    ValueTask<TResponse> DispatchAsync<TResponse>(
        IQuery<TResponse> query, CancellationToken ct);
}
