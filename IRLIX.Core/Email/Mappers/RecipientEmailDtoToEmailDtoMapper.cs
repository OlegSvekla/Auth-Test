using IRLIX.Core.Core.Interfaces.Mappers;
using IRLIX.Core.Email.Models;
using IRLIX.Core.Email.Providers;

namespace IRLIX.Core.Email.Mappers;

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
