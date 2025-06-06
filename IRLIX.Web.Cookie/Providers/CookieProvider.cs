using IRLIX.Web.Cookie.Configs;
using Microsoft.Extensions.Options;

namespace IRLIX.Web.Cookie.Providers;

public interface ICookieProvider
{
    CookieConfig GetConfigInfo();
}

public class CookieProvider(
    IOptions<CookieConfig> options
    ) : ICookieProvider
{
    private readonly CookieConfig config = options.Value;

    public CookieConfig GetConfigInfo()
        => config;
}
