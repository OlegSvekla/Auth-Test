using IRLIX.Aggregator.Ef.Entities.Auth;
using IRLIX.Web.Identity;
using static IRLIX.BL.Otps.Consts;

namespace IRLIX.BL.Otps;

public interface IOtpCodeClient
{
    Task<string> GenerateSingInEmailCodeAsync(
        string userName,
        CancellationToken ct);

    Task<string> GenerateSingInSmsCodeAsync(
        string userName,
        CancellationToken ct);

    Task<bool> ValidateSingInEmailCodeAsync(
        string userName,
        string token,
        CancellationToken ct);

    Task<bool> ValidateSingInSmsCodeAsync(
        string userName,
        string token,
        CancellationToken ct);
}

internal class FourDigitOtpCodeClient(
    IAuthUserManager<UserEntity> userManager
    ) : IOtpCodeClient
{
    public Task<string> GenerateSingInEmailCodeAsync(
        string userName,
        CancellationToken ct)
        => userManager.GenerateUserTokenAsync(userName, FourDigitEmailProvider, Consts.SignInEmail, ct);

    public Task<string> GenerateSingInSmsCodeAsync(
        string userName,
        CancellationToken ct)
        => userManager.GenerateUserTokenAsync(userName, FourDigitPhoneProvider, Consts.SignInSms, ct);

    public async Task<bool> ValidateSingInEmailCodeAsync(
        string userName,
        string token,
        CancellationToken ct)
    {
        var valid = await userManager.VerifyUserTokenAsync(userName, FourDigitEmailProvider, Consts.SignInEmail, token, ct);
        return valid;
    }

    public async Task<bool> ValidateSingInSmsCodeAsync(
        string userName,
        string token,
        CancellationToken ct)
    {
        var valid = await userManager.VerifyUserTokenAsync(userName, FourDigitPhoneProvider, Consts.SignInSms, token, ct);
        return valid;
    }
}
