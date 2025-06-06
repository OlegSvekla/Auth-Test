namespace IRLIX.Core.Interfaces.Storages;

public interface ICache
{
    ValueTask AddOrUpdateAsync<T>(
        string key,
        T value,
        CancellationToken ct = default)
        where T : notnull;

    ValueTask<T> GetAsync<T>(
        string key,
        CancellationToken ct = default);

    ValueTask<T?> FindAsync<T>(
    string key,
    CancellationToken ct = default);
}
