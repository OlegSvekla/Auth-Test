using IRLIX.Core.Exceptions;

namespace IRLIX.Core.ChainFuncs;

public class TryChainBuilder<T1, T2, TResult>
{
    private readonly IList<Func<T1, T2, TResult>> chain = [];
    private readonly IList<Exception> exs = [];
    private readonly int initialItemNumber;

    private TryChainBuilder(
        int initialItemNumber)
        => this.initialItemNumber = initialItemNumber;

    public static TryChainBuilder<T1, T2, TResult> Create(
        int initialItemNumber = 0)
        => new TryChainBuilder<T1, T2, TResult>(initialItemNumber);

    public TryChainBuilder<T1, T2, TResult> Try(
        Func<T1, T2, TResult> func)
    {
        chain.Add(func);
        return this;
    }

    public TResult BuildAsync(T1 arg1, T2 arg2)
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
                var result = func(arg1, arg2);
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
