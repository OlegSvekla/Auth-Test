using IRLIX.Core.Email.Mappers;
using IRLIX.Core.Email.Models;

namespace IRLIX.Core.Email;

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
