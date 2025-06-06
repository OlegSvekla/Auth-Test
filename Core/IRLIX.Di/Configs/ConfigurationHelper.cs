using IRLIX.Core.General;
using Microsoft.Extensions.Configuration;

namespace IRLIX.Di.Configs;

public static class ConfigurationHelper
{
    public static T Extract<T>(
        this IConfiguration config,
        string sectionKey)
        where T : class
        => config
            .GetSection(sectionKey)
            .Get<T>()
            .GetValue();
}
