using IRLIX.Core.Exceptions;

namespace IRLIX.Comm.Emails.MailKit.Gmail.Exceptions;

public class GmailEmailNotDeliveriedException(
    string message,
    Exception? innerEx = null
    ) : DomainException(
        message: message,
        innerEx: innerEx)
{
    public override int Code => (int)ExCodes.EmailNotDeliveried;

    public static GmailEmailNotDeliveriedException CreateWhenUnknownEx(Exception innerEx, string email, string subject)
        => new GmailEmailNotDeliveriedException(
            message: $"Gmail sender error: email '{email}' with subject '{subject}' has not been delivered due to internal error",
            innerEx: innerEx);

    public static void ThrowWhenNotDileveredSuccessfully(bool delivered, string email, string subject)
    {
        if (!delivered)
        {
            throw new GmailEmailNotDeliveriedException(
                message: $"Gmail sender error: email '{email}' with subject '{subject}' has not been delivered successfully");
        }
    }
}
