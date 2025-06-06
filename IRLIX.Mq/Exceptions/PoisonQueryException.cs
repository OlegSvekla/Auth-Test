using IRLIX.Core.Exceptions;
using IRLIX.Core.General;
using IRLIX.Mq.Messages;

namespace IRLIX.Mq.Exceptions;

public class PoisonQueryException(
    IQuery query,
    Exception? innerEx = null
    ) : DomainException(
        message: $"Poison query '{query.GetType().GetFriendlyShortName()}' has been found",
        innerEx: innerEx)
{
    public override int Code => (int)ExCodes.PoisonQuery;
}
