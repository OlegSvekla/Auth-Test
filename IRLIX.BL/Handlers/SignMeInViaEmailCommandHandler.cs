using IRLIX.Aggregator.Ef.Enums.Auth;
using IRLIX.BL.Otps;
using IRLIX.BL.Otps.Senders;
using IRLIX.BL.Shared.Modifiers.Creators;
using IRLIX.BL.Shared.Modifiers.Searchers;
using IRLIX.BL.Shared.Modifiers.Updaters;
using IRLIX.BL.Shared.Modifiers.Validators.SignInAttempts;
using IRLIX.Contracts.Commands.SignIns;
using IRLIX.Core.General;
using IRLIX.Mq.Local.MediatR.Handlers;
using IRLIX.Web.Identity.Lockouts;

namespace IRLIX.BL.Handlers;

public class SignMeInViaEmailCommandHandler(
    IUserWithEmailSearcher userWithEmailSearcher,
    ISignInAttemptCreator userSignInAttemptCreator,
    ILockoutClient lockoutClient,
    IAccessFailedCountValidator userSignInAttemptsCountValidator,
    IOtpCodeClient otpCodeClient,
    ISignInAttemptByCodeUpdater signInAttemptByCodeUpdater,
    IAggregatedEmailSender emailSender
    ) : MediatrCommandHandler<SignMeInViaEmailCommand>
{
    public override async ValueTask HandleAsync(
        SignMeInViaEmailCommand command,
        CancellationToken ct)
    {
        //TODO: implement ip validator to block in case of multiple calls

        var lowerCaseEmail = command.Email.ToLowerInvariant();
        var dto = await userWithEmailSearcher.ValidateAndGetAsync(lowerCaseEmail, ct);
        var userId = dto.UserId;
        var userName = dto.UserName.GetValue();

        var signInAttemptId = await userSignInAttemptCreator.CreateAsync(command.DeviceId, userId, UserSignInAttemptType.Email, ct);
        await lockoutClient.ValidateOrResetAsync(userId, userName, dto.Lockout, ct);
        var attemptsCount = await userSignInAttemptsCountValidator.ValidateAndGetAsync(userId, userName, ct);

        var code = !string.IsNullOrEmpty(dto.HardcodedCode)
            ? dto.HardcodedCode
            : await otpCodeClient.GenerateSingInEmailCodeAsync(userName, ct);
        await signInAttemptByCodeUpdater.UpdateAsync(signInAttemptId, code, ct);

        if (string.IsNullOrEmpty(dto.HardcodedCode))
        {
            await emailSender.SendOtpCodeAsync(code, dto.Email.GetValue(), attemptsCount, ct);
        }
    }
}
