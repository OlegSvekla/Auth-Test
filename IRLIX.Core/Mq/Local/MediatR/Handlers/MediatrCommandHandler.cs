namespace IRLIX.Core.Mq.Local.MediatR.Handlers;

public interface IMediatrCommandHandler<TCommand>
    : ICommandHandler<TCommand>,
    IRequestHandler<TCommand>
    where TCommand : IMediatrCommand;

public abstract class MediatrCommandHandler<TCommand>
    : IMediatrCommandHandler<TCommand>
    where TCommand : IMediatrCommand
{
    public Task Handle(
        TCommand request,
        CancellationToken cancellationToken)
        => HandleAsync(request, cancellationToken).AsTask();

    public abstract ValueTask HandleAsync(
        TCommand command,
        CancellationToken ct);
}
