using IRLIX.Core.Exceptions;
using IRLIX.Core.General;
using IRLIX.Mq.Messages;

namespace IRLIX.Mq.Exceptions;

public class PoisonCommandException(
    ICommand command,
    Exception? innerEx = null
    ) : DomainException(
        message: $"Poison command '{command.GetType().GetFriendlyShortName()}' has been found",
        innerEx: innerEx)
{
    public override int Code => (int)ExCodes.PoisonCommand;
}
