using IRLIX.Mq.Messages;
using MediatR;

namespace IRLIX.Mq.Local.MediatR.Messages;

public interface IMediatrQuery<out TResponse>
    : IQuery<TResponse>,
    IRequest<object>;
