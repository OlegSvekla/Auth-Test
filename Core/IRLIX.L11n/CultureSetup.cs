using IRLIX.L11n.Providers;
using System.Globalization;

namespace IRLIX.L11n;

public interface ICultureSetup
{
    void Set(string? cultureInfoStr);
}

public class CultureSetup(
    IL11nConfigProvider configProvider,
    ICultureInitializer cultureInitializer
    ) : ICultureSetup
{
    public void Set(string? cultureInfoStr)
    {
        var defaultCulureInfoStr = configProvider.GetDefaultCulture();
        var selectedCultureInfoStr = !string.IsNullOrWhiteSpace(cultureInfoStr)
            ? cultureInfoStr
            : defaultCulureInfoStr;

        CultureInfo culture;

        try
        {
            culture = new CultureInfo(selectedCultureInfoStr);
        }
        catch (CultureNotFoundException)
        {
            culture = new CultureInfo(defaultCulureInfoStr);
        }

        cultureInitializer.Init(culture);
    }
}
