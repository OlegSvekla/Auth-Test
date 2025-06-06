namespace IRLIX.Core.Exceptions;

public class ChainIsEmptyException(
    string message,
    Exception? innerEx = null
    ) : DomainException(
        message: message,
        innerEx: innerEx)
{
    public override int Code => (int)CoreExCodes.ChainIsEmpty;

    public static void ThrowWhenChainIsEmptySuccessfully<TSource>(
        IEnumerable<TSource> chain)
    {
        if (!chain.Any())
        {
            throw new ChainIsEmptyException(
                message: "Chain can't be empty");
        }
    }
}
