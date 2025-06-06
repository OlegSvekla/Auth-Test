namespace IRLIX.Core.Exceptions;

public class ChainFailedException(
    string message,
    Exception? innerEx = null
    ) : DomainException(
        message: message,
        innerEx: innerEx)
{
    public override int Code => (int)CoreExCodes.ChainFailed;

    public static ChainFailedException Create(
        IList<Exception> exs)
    {
        var exStrs = exs.Select(ex => ex.ToString()).ToArray();
        var aggregatedExStr = string.Join("\n", exStrs);
        return new ChainFailedException(
            message: $"Whole chain throw exceptions: {aggregatedExStr}");
    }
}
