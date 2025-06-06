using Microsoft.Extensions.Options;

namespace IRLIX.Di.Configs;

public static class ServiceProviderHelper
{
    public static T GetConfig<T>(this IServiceProvider serviceProvider)
        where T : class
    {
        var option = serviceProvider.GetRequiredService<IOptions<T>>();
        return option.Value;
    }
}
