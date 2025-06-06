using IRLIX.Core.Exceptions;
using IRLIX.Core.General;
using IRLIX.Mq.Messages;

namespace IRLIX.Mq.Exceptions;

public class PoisonEventException(
    IEvent @event,
    Exception? innerEx = null
    ) : DomainException(
        message: $"Poison event '{@event.GetType().GetFriendlyShortName()}' has been found",
        innerEx: innerEx)
{
    public override int Code => (int)ExCodes.PoisonEvent;
}
