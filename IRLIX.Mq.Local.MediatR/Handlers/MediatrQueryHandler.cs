using IRLIX.Mq.Handlers;
using IRLIX.Mq.Local.MediatR.Messages;
using IRLIX.Mq.Messages;
using MediatR;

namespace IRLIX.Mq.Local.MediatR.Handlers;

public interface IMediatrQueryHandler<TQuery, TResponse>
    : IQueryHandler<TQuery, TResponse>,
    IRequestHandler<TQuery, object>
    where TQuery : IMediatrQuery<TResponse>, IQuery<TResponse>, IRequest<object>;

public abstract class MediatrQueryHandler<TQuery, TResponse>
    : IMediatrQueryHandler<TQuery, TResponse>
    where TQuery : IMediatrQuery<TResponse>, IQuery<TResponse>, IRequest<object>
{
    public async Task<object> Handle(
        TQuery request,
        CancellationToken cancellationToken)
        => (await HandleAsync(request, cancellationToken))!;

    public abstract ValueTask<TResponse> HandleAsync(
        TQuery query,
        CancellationToken ct);
}
