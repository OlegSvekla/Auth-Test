using IRLIX.Core.Core.General;
using System.Resources;

namespace IRLIX.Core.L11n;

public interface IResourceProvider
{
    string GetLocalizedString(string key, params object?[] args);
}

public abstract class BaseResourceProvider : IResourceProvider
{
    private static ResourceManager? resourceManager;
    private readonly ICultureProvider cultureProvider;

    protected BaseResourceProvider(
        ICultureProvider cultureProvider)
    {
        this.cultureProvider = cultureProvider;
        resourceManager ??= GetResourceManager();
    }

    protected abstract ResourceManager GetResourceManager();

    public string GetLocalizedString(string key, params object?[] args)
    {
        var culture = cultureProvider.Get();
        var textOrTemplate = resourceManager.GetValue().GetString(key, culture).GetValue();

        if (args.Any())
        {
            textOrTemplate = string.Format(culture, textOrTemplate, args);
        }

        return textOrTemplate;
    }
}
