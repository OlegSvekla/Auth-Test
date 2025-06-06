using IRLIX.Mq.Messages;
using MediatR;

namespace IRLIX.Mq.Local.MediatR.Messages;

public interface IMediatrEvent : IEvent, INotification;
