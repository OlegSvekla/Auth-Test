using MimeKit.Text;

namespace IRLIX.Comm.Emails.MailKit.Models;

public record RecipientEmailDto(
    string Email,
    string Subject,
    string Message,
    TextFormat Format = TextFormat.Text
    );
