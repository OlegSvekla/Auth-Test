namespace IRLIX.Web.Models.Rss.Errors;

public record UserLockedOutErrorRs(
    int? Code,
    DateTimeOffset LockoutEndDate,
    string LockoutReason
    ) : BaseErrorRs(
        Code);
