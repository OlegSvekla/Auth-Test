using IRLIX.Core.Mq.Messages;

namespace IRLIX.Core.Mq.Buses;

public interface ICommandDispatcher
{
    ValueTask DispatchAsync(ICommand command, CancellationToken ct);
}
