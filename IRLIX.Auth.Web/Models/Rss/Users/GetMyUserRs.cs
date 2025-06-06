namespace IRLIX.Auth.Web.Models.Rss.Users;

public record GetMyUserRs(
    string? Phone,
    bool IsPhoneVerified,
    string? Email,
    bool IsEmailVerified
    );

