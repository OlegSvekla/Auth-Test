using IRLIX.Core.Mq.Messages;

namespace IRLIX.Core.Mq.Buses;

public interface IQueryDispatcher
{
    ValueTask<TResponse> DispatchAsync<TResponse>(
        IQuery<TResponse> query, CancellationToken ct);
}
