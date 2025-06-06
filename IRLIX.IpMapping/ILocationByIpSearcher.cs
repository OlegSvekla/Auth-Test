using IRLIX.IpMapping.Models;

namespace IRLIX.IpMapping;

public interface ILocationByIpSearcher
{
    ValueTask<FoundLocation> SearchLocationByIpAsync(
        string ip,
        CancellationToken ct);
}
