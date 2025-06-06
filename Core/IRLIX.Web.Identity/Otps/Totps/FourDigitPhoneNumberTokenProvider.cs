using IRLIX.Ef.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace IRLIX.Web.Identity.Otps.Totps;

/// <summary>
/// Code created by support https://github.com/aspnet/Identity/blob/master/src/Core/PhoneNumberTokenProvider.cs
/// </summary>
/// <typeparam name="TUser"></typeparam>
public class FourDigitPhoneNumberTokenProvider<TUser>
    : PhoneNumberTokenProvider<TUser>
    where TUser : EfIdentityUserEntity
{
    /// <summary>
    /// Code created by support https://github.com/aspnet/Identity/blob/master/src/Core/TotpSecurityStampBasedTokenProvider.cs
    /// </summary>
    /// <param name="purpose"></param>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public override async Task<string> GenerateAsync(
        string purpose,
        UserManager<TUser> manager,
        TUser user)
    {
        ArgumentNullException.ThrowIfNull(manager);

        await manager.UpdateSecurityStampAsync(user);
        var securityToken = await manager.CreateSecurityTokenAsync(user);
        var token = new OtpSecurityToken(securityToken);
        var modifier = await GetUserModifierAsync(purpose, manager, user);

        var code = Rfc6238AuthenticationService
            .GenerateCode(token, modifier)
            .ToString("D4", CultureInfo.InvariantCulture);
        return code;
    }

    /// <summary>
    /// Code created by support https://github.com/aspnet/Identity/blob/master/src/Core/TotpSecurityStampBasedTokenProvider.cs
    /// </summary>
    /// <param name="purpose"></param>
    /// <param name="token"></param>
    /// <param name="manager"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public override async Task<bool> ValidateAsync(
        string purpose,
        string token,
        UserManager<TUser> manager,
        TUser user)
    {
        ArgumentNullException.ThrowIfNull(manager);

        if (!int.TryParse(token, out var code))
        {
            return false;
        }

        var securityToken = new OtpSecurityToken(await manager.CreateSecurityTokenAsync(user));
        var modifier = await GetUserModifierAsync(purpose, manager, user);
        var valid = Rfc6238AuthenticationService.ValidateCode(securityToken, code, modifier, token.Length);
        return valid;
    }
}
