using IRLIX.Mq.Messages;

namespace IRLIX.Mq.Buses;

public interface ICommandDispatcher
{
    ValueTask DispatchAsync(ICommand command, CancellationToken ct);
}
