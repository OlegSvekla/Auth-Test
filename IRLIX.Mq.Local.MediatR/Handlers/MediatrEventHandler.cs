using IRLIX.Mq.Handlers;
using IRLIX.Mq.Local.MediatR.Messages;
using MediatR;

namespace IRLIX.Mq.Local.MediatR.Handlers;

public interface IMediatrEventHandler<TEvent>
    : IEventHandler<TEvent>,
    INotificationHandler<TEvent>
    where TEvent : IMediatrEvent;

public abstract class MediatrEventHandler<TEvent>
    : IMediatrEventHandler<TEvent>
    where TEvent : IMediatrEvent
{
    public Task Handle(
        TEvent notification,
        CancellationToken cancellationToken)
        => HandleAsync(notification, cancellationToken).AsTask();

    public abstract ValueTask HandleAsync(
        TEvent @event,
        CancellationToken ct);
}
