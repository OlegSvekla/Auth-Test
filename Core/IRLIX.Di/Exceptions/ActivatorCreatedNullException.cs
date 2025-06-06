using IRLIX.Core.Exceptions;

namespace IRLIX.Di.Exceptions;

public sealed class ActivatorCreatedNullException(
    Type type,
    Exception? innerEx = null
    ) : DomainException(
        message: $"Activator created null instead of type {type.FullName}",
        innerEx: innerEx)
{
    public override int Code => (int)ExCodes.ActivatorCreatedNull;
}
