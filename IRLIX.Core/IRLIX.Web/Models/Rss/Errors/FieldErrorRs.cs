namespace IRLIX.Core.IRLIX.Web.Models.Rss.Errors;

public record FieldErrorRs(
    int? Code,
    string Message,
    string Field
    ) : MessageErrorRs(
        Code,
        Message);
