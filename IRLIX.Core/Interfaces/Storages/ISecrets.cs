namespace IRLIX.Core.Interfaces.Storages;

public interface ISecrets
{
    ValueTask AddOrUpdateAsync(
        string key,
        IDictionary<string, string> value,
        CancellationToken ct = default);

    ValueTask<IDictionary<string, string>?> FindAsync(
        string key,
        CancellationToken ct = default);
}
