using IRLIX.Mq.Messages;

namespace IRLIX.Mq.Buses;

public interface IEventDispatcher
{
    ValueTask DispatchAsync(IEvent @event, CancellationToken ct);
}
