namespace IRLIX.Core.Email.Models;

public record EmailDto(
    SenderEmailDto Sender,
    RecipientEmailDto Recipient
    );
