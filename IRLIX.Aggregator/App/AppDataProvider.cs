using IRLIX.Core.Interfaces.App;

namespace IRLIX.Aggregator.App;

public sealed class AppDataProvider : IAppDataProvider
{
    public string GetName()
        => Consts.AppName;
}
