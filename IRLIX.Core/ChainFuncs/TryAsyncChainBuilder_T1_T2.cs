using IRLIX.Core.Exceptions;

namespace IRLIX.Core.ChainFuncs;

public class TryAsyncChainBuilder<T1, T2, TResult>
{
    private readonly IList<Func<T1, T2, CancellationToken, ValueTask<TResult>>> chain = [];
    private readonly IList<Exception> exs = [];
    private readonly int initialItemNumber;

    private TryAsyncChainBuilder(
        int initialItemNumber)
        => this.initialItemNumber = initialItemNumber;

    public static TryAsyncChainBuilder<T1, T2, TResult> Create(
        int initialItemNumber = 0)
        => new TryAsyncChainBuilder<T1, T2, TResult>(initialItemNumber);

    public TryAsyncChainBuilder<T1, T2, TResult> Try(
        Func<T1, T2, CancellationToken, ValueTask<TResult>> func)
    {
        chain.Add(func);
        return this;
    }

    public async ValueTask<TResult> BuildAsync(T1 arg1, T2 arg2, CancellationToken ct)
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
                var result = await func(arg1, arg2, ct);
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
