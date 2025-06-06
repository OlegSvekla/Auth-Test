using IRLIX.Core.General;
using System.Globalization;

namespace IRLIX.L11n;

public interface ICultureInitializer
{
    void Init(CultureInfo culture);
}

public interface ICultureProvider
{
    CultureInfo Get();
}

public class CultureStorage
    : ICultureInitializer,
    ICultureProvider
{
    private CultureInfo? currentCulture;

    public CultureInfo Get()
        => currentCulture.GetValue();

    public void Init(CultureInfo culture)
        => currentCulture = culture;
}

