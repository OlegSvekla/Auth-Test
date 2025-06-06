using IRLIX.Core.Exceptions;

namespace IRLIX.Core.ChainFuncs;

public class TryChainBuilder<T>
{
    private readonly IList<Action<T>> chain = [];
    private readonly IList<Exception> exs = [];
    private readonly int initialItemNumber;

    private TryChainBuilder(
        int initialItemNumber)
        => this.initialItemNumber = initialItemNumber;

    public static TryChainBuilder<T> Create(
        int initialItemNumber = 0)
        => new TryChainBuilder<T>(initialItemNumber);

    public TryChainBuilder<T> Try(
        Action<T> func)
    {
        chain.Add(func);
        return this;
    }

    public void Build(T arg)
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
                func(arg);
                return;
            }
            catch (Exception ex)
            {
                exs.Add(ex);
            }
        }

        throw ChainFailedException.Create(exs);
    }
}
