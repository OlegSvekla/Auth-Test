using IRLIX.Core.Mq.Messages;

namespace IRLIX.Core.Mq.Local.MediatR.Handlers;

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    ValueTask HandleAsync(TCommand command, CancellationToken ct);
}
