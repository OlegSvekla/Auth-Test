using IRLIX.Comm.Emails.MailKit.Gmail.Providers;
using IRLIX.Comm.Emails.MailKit.Models;
using IRLIX.Core.Interfaces.Mappers;

namespace IRLIX.Comm.Emails.MailKit.Gmail.Mappers;

public interface IRecipientEmailDtoToEmailDtoMapper
    : IMapper<RecipientEmailDto, EmailDto>;

public class RecipientEmailDtoToEmailDtoMapper(
    IGmailEmailConfigProvider configProvider
    ) : IRecipientEmailDtoToEmailDtoMapper
{
    public EmailDto Map(RecipientEmailDto input)
    {
        var emailConfig = configProvider.GetAuthConfig();
        var sender = new SenderEmailDto(
            Email: emailConfig.Email,
            Password: emailConfig.Password,
            Host: emailConfig.Host,
            Port: emailConfig.Port);

        var message = new EmailDto(
            Sender: sender,
            Recipient: input);
        return message;
    }
}
