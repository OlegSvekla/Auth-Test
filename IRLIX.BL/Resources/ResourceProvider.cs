using IRLIX.L11n;
using System.Reflection;
using System.Resources;

namespace IRLIX.BL.Resources;

internal class ResourceProvider(
    ICultureProvider cultureProvider
    ) : BaseResourceProvider(
        cultureProvider
        )
{
    protected override ResourceManager GetResourceManager()
        => new ResourceManager(Consts.ResourceName, Assembly.GetExecutingAssembly());
}
