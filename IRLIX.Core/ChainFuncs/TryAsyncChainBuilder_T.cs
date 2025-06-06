using IRLIX.Core.Exceptions;

namespace IRLIX.Core.ChainFuncs;

public class TryAsyncChainBuilder<T, TResult>
{
    private readonly IList<Func<T, CancellationToken, ValueTask<TResult>>> chain = [];
    private readonly IList<Exception> exs = [];
    private readonly int initialItemNumber;

    private TryAsyncChainBuilder(
        int initialItemNumber)
        => this.initialItemNumber = initialItemNumber;

    public static TryAsyncChainBuilder<T, TResult> Create(
        int initialItemNumber = 0)
        => new TryAsyncChainBuilder<T, TResult>(initialItemNumber);

    public TryAsyncChainBuilder<T, TResult> Try(
        Func<T, CancellationToken, ValueTask<TResult>> func)
    {
        chain.Add(func);
        return this;
    }

    public async ValueTask<TResult> BuildAsync(T arg, CancellationToken ct)
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
                var result = await func(arg, ct);
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
