using MimeKit.Text;

namespace IRLIX.Core.Email.Models;

public record RecipientEmailDto(
    string Email,
    string Subject,
    string Message,
    TextFormat Format = TextFormat.Text
    );
