namespace IRLIX.Core.Core.ChainFuncs;

public class TryAsyncChainBuilder<T>
{
    private readonly IList<Func<T, CancellationToken, ValueTask>> chain = [];
    private readonly IList<Exception> exs = [];
    private readonly int initialItemNumber;

    private TryAsyncChainBuilder(
        int initialItemNumber)
        => this.initialItemNumber = initialItemNumber;

    public static TryAsyncChainBuilder<T> Create(
        int initialItemNumber = 0)
        => new TryAsyncChainBuilder<T>(initialItemNumber);

    public TryAsyncChainBuilder<T> Try(
        Func<T, CancellationToken, ValueTask> func)
    {
        chain.Add(func);
        return this;
    }

    public async ValueTask BuildAsync(T arg, CancellationToken ct)
    {
        //ChainIsEmptyException.ThrowWhenChainIsEmptySuccessfully(chain);

        var startIndex = initialItemNumber < chain.Count
            ? initialItemNumber
            : chain.Count - 1;

        for (var i = startIndex; i < chain.Count; i++)
        {
            var func = chain[i];

            try
            {
                await func(arg, ct);
                return;
            }
            catch (Exception ex)
            {
                exs.Add(ex);
            }
        }

        //throw ChainFailedException.Create(exs);
    }
}
