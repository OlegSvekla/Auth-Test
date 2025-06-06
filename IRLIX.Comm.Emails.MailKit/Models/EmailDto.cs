namespace IRLIX.Comm.Emails.MailKit.Models;

public record EmailDto(
    SenderEmailDto Sender,
    RecipientEmailDto Recipient
    );
