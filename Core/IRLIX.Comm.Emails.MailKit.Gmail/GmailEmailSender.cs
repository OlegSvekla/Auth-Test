using IRLIX.Comm.Emails.MailKit.Gmail.Exceptions;
using IRLIX.Comm.Emails.MailKit.Gmail.Mappers;
using IRLIX.Comm.Emails.MailKit.Models;

namespace IRLIX.Comm.Emails.MailKit.Gmail;

public interface IGmailEmailSender : IEmailSender;

public sealed class GmailEmailSender(
    IRecipientEmailDtoToEmailDtoMapper mapper
    ) : EmailSender, IGmailEmailSender
{
    public override async ValueTask SendAsync(
        RecipientEmailDto recipient,
        CancellationToken ct = default)
    {
        try
        {
            var email = mapper.Map(recipient);
            var result = await InnerSendAsync(email, ct);
            GmailEmailNotDeliveriedException.ThrowWhenNotDileveredSuccessfully(result, recipient.Email, recipient.Subject);
        }
        catch (Exception ex)
        {
            throw GmailEmailNotDeliveriedException.CreateWhenUnknownEx(ex, recipient.Email, recipient.Subject);
        }
    }
}
