namespace IRLIX.BL;

internal static class Consts
{
    internal static readonly IDictionary<int, TimeSpan> LockoutAttemptToDurationDict
        = new Dictionary<int, TimeSpan>
        {
        { 105, TimeSpan.FromMinutes(5) },
        { 110, TimeSpan.FromMinutes(15) },
        { 115, TimeSpan.FromHours(24) },
        { 120, TimeSpan.MaxValue }
        };

    internal const string LockoutSystemReason = "The user has been blocked by the system due to suspicious activity";
    internal const int SignInAttemptsValidTimeSpanHour = 24;
    internal const int LastSignInAttemptsCount = 120;
    internal const int AccessFailedIncAfterSignInAttemptsCount = 1;
    internal const int ValidTimeSpanToBeAuthorizedMin = 15;
}
