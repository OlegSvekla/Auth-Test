using IRLIX.Aggregator.Ef.Entities.Auth;
using IRLIX.Aggregator.Ef.Enums.Auth;
using IRLIX.Auth.Contracts.Commands.VerifyCodes;
using IRLIX.BL.Exceptions.VerifyCodes;
using IRLIX.BL.Otps;
using IRLIX.BL.Shared.Lockouts;
using IRLIX.BL.Shared.Modifiers.Creators;
using IRLIX.BL.Shared.Modifiers.Searchers;
using IRLIX.BL.Shared.Modifiers.Updaters;
using IRLIX.BL.Shared.Modifiers.Validators.SignInAttempts;
using IRLIX.Core.General;
using IRLIX.Mq.Local.MediatR.Handlers;
using IRLIX.Web.Identity;
using IRLIX.Web.Identity.Lockouts;

namespace IRLIX.BL.Handlers.Commands;

internal class VerifyCodeByMeViaEmailCommandHandler(
    IUserLockoutSetter userLockoutSetter,
    IUserWithEmailSearcher userWithEmailSearcher,
    ILockoutClient lockoutClient,
    ILastSignInAttemptValidator lastSignInAttemptValidator,
    IOtpCodeClient otpCodeClient,
    IUserFieldConfirmedUpdater userFieldConfirmedUpdater,
    ISessionCreator sessionCreator,
    IAuthUserManager<UserEntity> userManager
    ) : MediatrCommandHandler<VerifyCodeByMeViaEmailCommand>
{
    public override async ValueTask HandleAsync(
        VerifyCodeByMeViaEmailCommand command,
        CancellationToken ct)
    {
        try
        {
            await InnerHandleAsync(command, ct);
        }
        catch (SignInAttemptIsInvalidException ex)
        {
            await userLockoutSetter.TrySetAccessFailedAndTryLockAsync(ex.UserId, ex.UserName, ct: ct);
            throw;
        }
        catch (CodeIsIncorrectException ex)
        {
            await userLockoutSetter.TrySetAccessFailedAndTryLockAsync(ex.UserId, ex.UserName, ct: ct);
            throw;
        }
    }

    private async ValueTask InnerHandleAsync(
        VerifyCodeByMeViaEmailCommand command,
        CancellationToken ct)
    {
        var lowerCaseEmail = command.Email.ToLowerInvariant();
        var dto = await userWithEmailSearcher.ValidateAndGetAsync(lowerCaseEmail, ct);
        await lockoutClient.ValidateOrResetAsync(dto.UserId, dto.UserName.GetValue(), dto.Lockout, ct);

        var userName = dto.UserName.GetValue();
        var signInType = UserSignInAttemptType.Email;

        var signInAttemptId = await lastSignInAttemptValidator.ValidateAndGetIdAsync(command.DeviceId, signInType, command.Code, dto.UserId, userName, ct);
        var valid = !string.IsNullOrEmpty(dto.HardcodedCode)
            ? dto.HardcodedCode.Equals(command.Code, StringComparison.OrdinalIgnoreCase)
            : await otpCodeClient.ValidateSingInEmailCodeAsync(userName, command.Code, ct);
        CodeIsIncorrectException.ThrowWhenInvalid(valid, dto.UserId, userName);

        await userFieldConfirmedUpdater.SetEmailConfirmedAsync(userName, ct);
        var createdSessionId = await sessionCreator.CreateBySignInAttemptAsync(dto.UserId, signInAttemptId, ct);

        await userManager.ResetAccessFailedCountAsync(userName, ct);

        command.Id = createdSessionId;
    }
}
