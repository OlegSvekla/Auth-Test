namespace IRLIX.Auth.Web.Models;

internal static class Consts
{
    internal const string PhoneExpression = @"^\+\d{2,20}$";

    internal const int MinLengthOfNames = 2;
    internal const int MaxLengthOfNames = 30;
    internal const int LengthOfLanguage = 2;

    internal const int VerifyCodeLength = 4;
    internal const int MinResendAttempt = 0;
}
