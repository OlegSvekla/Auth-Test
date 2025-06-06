using IRLIX.Mq.Messages;
using MediatR;

namespace IRLIX.Mq.Local.MediatR.Messages;

public interface IMediatrCommand : ICommand, IRequest;

public interface IMediatrCreateCommand : IMediatrCommand, ICreateCommand;
