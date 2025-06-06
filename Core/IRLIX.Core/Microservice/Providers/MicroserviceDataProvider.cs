using IRLIX.Core.Microservice.Config;
using Microsoft.Extensions.Options;

namespace IRLIX.Core.Microservice.Providers;

public interface IMicroserviceDataProvider
{
    string GetName();
}

public sealed class MicroserviceDataProvider(
    IOptions<MicroserviceConfig> options
    ) : IMicroserviceDataProvider
{
    private readonly MicroserviceConfig config = options.Value;

    public string GetName()
        => config.Name;
}
