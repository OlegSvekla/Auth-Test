using IRLIX.Core.Core.General;
using IRLIX.Core.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IRLIX.Core.Identity;

public interface IAuthUserManager<TUser>
    where TUser : EfIdentityUserEntity
{
    #region Create user

    Task<TUser?> FindByNameAsync(
        string userName,
        CancellationToken ct);

    Task<IList<Claim>> GetClaimsAsync(
        string userName,
        CancellationToken ct);

    Task<IList<string>> GetRolesAsync(
        string userName,
        CancellationToken ct);

    #endregion Create user

    #region Create user

    Task<TUser> CreateAsync(
        TUser user,
        CancellationToken ct);

    #endregion Create user

    #region User token

    Task<string> GenerateUserTokenAsync(
        string userName,
        string tokenProvider,
        string purpose,
        CancellationToken ct);

    Task<bool> VerifyUserTokenAsync(
        string userName,
        string tokenProvider,
        string purpose,
        string token,
        CancellationToken ct);

    #endregion User token

    #region Access failed and lockout

    Task<int> GetAccessFailedCountAsync(
        string userName,
        CancellationToken ct);

    Task<int> AccessFailedAsync(
        string userName,
        CancellationToken ct);

    Task ResetAccessFailedCountAsync(
        string userName,
        CancellationToken ct);

    Task<bool> GetLockoutEnabledAsync(
        string userName,
        CancellationToken ct);

    Task<DateTimeOffset?> GetLockoutEndDateAsync(
        string userName,
        CancellationToken ct);

    Task SetLockoutEndDateAsync(
        string userName,
        DateTimeOffset? lockoutEndDate,
        CancellationToken ct);

    #endregion Access failed and lockout

    #region Confirm field

    Task ConfirmEmailAsync(
        string userName,
        CancellationToken ct);

    Task ConfirmPhoneAsync(
        string userName,
        CancellationToken ct);

    #endregion Confirm field

    #region Update field

    Task SetEmailAsync(
        string userName,
        string newEmail,
        CancellationToken ct);

    Task SetPhoneAsync(
        string userName,
        string newPhone,
        CancellationToken ct);

    #endregion Update field

    #region CheckPassword

    Task<bool> CheckPasswordAsync(
        string userName,
        string password,
        CancellationToken ct);

    #endregion CheckPassword
}

internal class AuthUserManager<TUser>(
    UserManager<TUser> userManager
    ) : IAuthUserManager<TUser>
    where TUser : EfIdentityUserEntity
{
    #region Find user

    public async Task<TUser?> FindByNameAsync(
        string userName,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var user = await userManager.FindByNameAsync(userName);

        return user;
    }

    public async Task<IList<Claim>> GetClaimsAsync(
        string userName,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var foundUser = await userManager.FindByNameAsync(userName);
        var user = foundUser.GetValue();
        var result = await userManager.GetClaimsAsync(user);

        return result;
    }

    public async Task<IList<string>> GetRolesAsync(
        string userName,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var foundUser = await userManager.FindByNameAsync(userName);
        var user = foundUser.GetValue();
        var result = await userManager.GetRolesAsync(user);

        return result;
    }

    #endregion Find user

    #region Create user

    public async Task<TUser> CreateAsync(
        TUser user,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var identityResult = await userManager.CreateAsync(user);
        BadIdentityResultException.ThrowWhenNotSuccess(identityResult);

        return user;
    }

    #endregion Create user

    #region User token

    public async Task<string> GenerateUserTokenAsync(
        string userName,
        string tokenProvider,
        string purpose,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var foundUser = await userManager.FindByNameAsync(userName);
        var user = foundUser.GetValue();
        var result = await userManager.GenerateUserTokenAsync(user, tokenProvider, purpose);

        return result;
    }

    public async Task<bool> VerifyUserTokenAsync(
        string userName,
        string tokenProvider,
        string purpose,
        string token,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var foundUser = await userManager.FindByNameAsync(userName);
        var user = foundUser.GetValue();
        var result = await userManager.VerifyUserTokenAsync(user, tokenProvider, purpose, token);

        return result;
    }

    #endregion User token

    #region Access failed and lockout

    public async Task<int> GetAccessFailedCountAsync(
        string userName,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var foundUser = await userManager.FindByNameAsync(userName);
        var user = foundUser.GetValue();
        var accessFailedCount = await userManager.GetAccessFailedCountAsync(user);

        return accessFailedCount;
    }

    public async Task<int> AccessFailedAsync(
        string userName,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var foundUser = await userManager.FindByNameAsync(userName);
        var user = foundUser.GetValue();
        var identityResult = await userManager.AccessFailedAsync(user);

        BadIdentityResultException.ThrowWhenNotSuccess(identityResult);
        return user.AccessFailedCount;
    }

    public async Task ResetAccessFailedCountAsync(
        string userName,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var foundUser = await userManager.FindByNameAsync(userName);
        var user = foundUser.GetValue();
        var identityResult = await userManager.ResetAccessFailedCountAsync(user);

        BadIdentityResultException.ThrowWhenNotSuccess(identityResult);
    }

    public async Task<bool> GetLockoutEnabledAsync(
        string userName,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var foundUser = await userManager.FindByNameAsync(userName);
        var user = foundUser.GetValue();
        var result = await userManager.GetLockoutEnabledAsync(user);

        return result;
    }

    public async Task<DateTimeOffset?> GetLockoutEndDateAsync(
        string userName,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var foundUser = await userManager.FindByNameAsync(userName);
        var user = foundUser.GetValue();
        var result = await userManager.GetLockoutEndDateAsync(user);

        return result;
    }

    public async Task SetLockoutEndDateAsync(
        string userName,
        DateTimeOffset? lockoutEndDate,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var foundUser = await userManager.FindByNameAsync(userName);
        var user = foundUser.GetValue();
        var identityResult = await userManager.SetLockoutEndDateAsync(user, lockoutEndDate);

        BadIdentityResultException.ThrowWhenNotSuccess(identityResult);
    }

    #endregion Access failed and lockout

    #region Confirm field

    public async Task ConfirmEmailAsync(
        string userName,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var foundUser = await userManager.FindByNameAsync(userName);
        var user = foundUser.GetValue();
        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        var identityResult = await userManager.ConfirmEmailAsync(user, token);

        BadIdentityResultException.ThrowWhenNotSuccess(identityResult);
    }

    public async Task ConfirmPhoneAsync(
        string userName,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var foundUser = await userManager.FindByNameAsync(userName);
        var user = foundUser.GetValue();
        user.PhoneNumberConfirmed = true;
        var identityResult = await userManager.UpdateAsync(user);

        BadIdentityResultException.ThrowWhenNotSuccess(identityResult);
    }

    #endregion Confirm field

    #region Update field

    public async Task SetEmailAsync(
        string userName,
        string newEmail,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var foundUser = await userManager.FindByNameAsync(userName);
        var user = foundUser.GetValue();
        var identityResult = await userManager.SetEmailAsync(user, newEmail);

        BadIdentityResultException.ThrowWhenNotSuccess(identityResult);
    }

    public async Task SetPhoneAsync(
        string userName,
        string newPhone,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var foundUser = await userManager.FindByNameAsync(userName);
        var user = foundUser.GetValue();
        var identityResult = await userManager.SetPhoneNumberAsync(user, newPhone);

        BadIdentityResultException.ThrowWhenNotSuccess(identityResult);
    }

    #endregion Update field

    #region CheckPassword

    public async Task<bool> CheckPasswordAsync(
        string userName,
        string password,
        CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var foundUser = await userManager.FindByNameAsync(userName);
        var user = foundUser.GetValue();
        var valid = await userManager.CheckPasswordAsync(user, password);

        return valid;
    }

    #endregion CheckPassword
}
