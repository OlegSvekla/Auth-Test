namespace IRLIX.Core.Email.Models;

public record SenderEmailDto(
    string Email,
    string Password,
    string Host,
    int Port
    );
