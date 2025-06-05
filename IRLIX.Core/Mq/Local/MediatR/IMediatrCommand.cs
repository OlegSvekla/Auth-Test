using IRLIX.Core.Mq.Messages;

namespace IRLIX.Core.Mq.Local.MediatR;

public interface IMediatrCommand : ICommand, IRequest;

public interface IMediatrCreateCommand : IMediatrCommand, ICreateCommand;
