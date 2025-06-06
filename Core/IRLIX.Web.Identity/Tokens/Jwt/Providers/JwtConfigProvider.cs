using IRLIX.Web.Identity.Tokens.Jwt.Configs;
using Microsoft.Extensions.Options;

namespace IRLIX.Web.Identity.Tokens.Jwt.Providers;

public interface IJwtConfigProvider
{
    JwtConfig GetJwtConfig();
}

public sealed class JwtConfigProvider(
    IOptions<JwtConfig> options
    ) : IJwtConfigProvider
{
    private readonly JwtConfig config = options.Value;

    public JwtConfig GetJwtConfig()
        => config;
}
