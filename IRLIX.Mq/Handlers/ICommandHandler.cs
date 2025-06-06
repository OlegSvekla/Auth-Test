using IRLIX.Mq.Messages;

namespace IRLIX.Mq.Handlers;

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    ValueTask HandleAsync(TCommand command, CancellationToken ct);
}
