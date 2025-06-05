namespace IRLIX.Core.IRLIX.Web.Models.Rss.Errors;

public record MessageErrorRs(
    int? Code,
    string Message
    ) : BaseErrorRs(
        Code);
