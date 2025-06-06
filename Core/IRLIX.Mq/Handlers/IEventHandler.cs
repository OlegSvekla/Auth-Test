using IRLIX.Mq.Messages;

namespace IRLIX.Mq.Handlers;

public interface IEventHandler<in TEvent>
    where TEvent : IEvent
{
    ValueTask HandleAsync(TEvent @event, CancellationToken ct);
}