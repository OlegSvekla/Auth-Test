using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IRLIX.Core.Identity.Tokens.Jwt.Configs;

public sealed class JwtConfig
{
    public string SigningSecretKey { get; set; } = default!;

    public string AuthScheme { get; set; } = JwtBearerDefaults.AuthenticationScheme;

    public string IssuerAuthHost { get; set; } = default!;

    public string AudienceAuthHost { get; set; } = default!;

    public int AccessTokenLifeTimeMin { get; set; } = Consts.TwoWeekMin;

    public int RefreshTokenLifeTimeMin { get; set; } = Consts.OneMonthMin;
}
