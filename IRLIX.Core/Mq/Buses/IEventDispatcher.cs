using IRLIX.Core.Mq.Messages;

namespace IRLIX.Core.Mq.Buses;

public interface IEventDispatcher
{
    ValueTask DispatchAsync(IEvent @event, CancellationToken ct);
}
