using IRLIX.Core.Exceptions;

namespace IRLIX.Core.ChainFuncs;

public class TryChainBuilder<T, TResult>
{
    private readonly IList<Func<T, TResult>> chain = [];
    private readonly IList<Exception> exs = [];
    private readonly int initialItemNumber;

    private TryChainBuilder(
        int initialItemNumber)
        => this.initialItemNumber = initialItemNumber;

    public static TryChainBuilder<T, TResult> Create(
        int initialItemNumber = 0)
        => new TryChainBuilder<T, TResult>(initialItemNumber);

    public TryChainBuilder<T, TResult> Try(
        Func<T, TResult> func)
    {
        chain.Add(func);
        return this;
    }

    public TResult Build(T arg)
    {
        ChainIsEmptyException.ThrowWhenChainIsEmptySuccessfully(chain);

        var startIndex = initialItemNumber < chain.Count
            ? initialItemNumber
            : chain.Count - 1;

        for (var i = startIndex; i < chain.Count; i++)
        {
            var func = chain[i];

            try
            {
                var result = func(arg);
                return result;
            }
            catch (Exception ex)
            {
                exs.Add(ex);
            }
        }

        throw ChainFailedException.Create(exs);
    }
}
