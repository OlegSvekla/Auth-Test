using IRLIX.BL.Resources;
using IRLIX.Comm.Emails.MailKit.Gmail;
using IRLIX.Comm.Emails.MailKit.Models;
using IRLIX.Core.ChainFuncs;
using IRLIX.L11n;

namespace IRLIX.BL.Otps.Senders;

public interface IAggregatedEmailSender
{
    ValueTask SendOtpCodeAsync(
        string code,
        string email,
        int attemptsCount = 1,
        CancellationToken ct = default);
}

public sealed class AggregatedEmailSender(
    IGmailEmailSender gmailEmailSender,
    IResourceProvider resourceProvider
    ) : IAggregatedEmailSender
{
    public async ValueTask SendOtpCodeAsync(
        string code,
        string email,
        int attemptsCount = 1,
        CancellationToken ct = default)
    {
        var subject = resourceProvider.GetLocalizedString(ResourceKeys.SendEmailOtpCodeSubject);
        var message = resourceProvider.GetLocalizedString(ResourceKeys.SendEmailOtpCodeMessage, code);

        var recipient = new RecipientEmailDto(email, subject, message);
        var initialItemNumber = attemptsCount - 1;
        await SendAsync(recipient, initialItemNumber, ct);
    }

    private ValueTask SendAsync(
        RecipientEmailDto recipient,
        int initialItemNumber,
        CancellationToken ct = default)
        => TryAsyncChainBuilder<RecipientEmailDto>.Create(initialItemNumber)
            .Try(gmailEmailSender.SendAsync)
            .BuildAsync(recipient, ct);
}
