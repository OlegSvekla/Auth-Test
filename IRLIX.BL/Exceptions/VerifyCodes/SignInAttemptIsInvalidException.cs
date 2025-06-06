using IRLIX.Core.Attributes;
using IRLIX.Core.Exceptions;
using System.Diagnostics.CodeAnalysis;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IRLIX.BL.Exceptions.VerifyCodes;

[HttpResponseStatusCode(Status400BadRequest)]
public class SignInAttemptIsInvalidException(
    Guid? userId = null,
    string? userName = null,
    Exception? innerEx = null
    ) : DomainException(
        message: ErrorMessage,
        innerEx: innerEx)
{
    private const string ErrorMessage = "Sign in attempt is invalid";
    public override int Code => (int)ExCodes.CodeOrEmailAreIncorrect;
    public string? UserName { get; } = userName;
    public Guid? UserId { get; } = userId;

    public static void ThrowWhenSignInAttemptNotExist<T>(
        [NotNull] T? signInAttempt,
        Guid userId,
        string userName)
    {
        if (signInAttempt == null)
        {
            throw new SignInAttemptIsInvalidException(userId, userName);
        }
    }

    public static void ThrowWhenSignInAttemptDontPassValidDateTime(
        DateTimeOffset signInAttemptCreatedDate,
        DateTimeOffset validDateTimeOffset,
        Guid userId,
        string userName)
    {
        if (signInAttemptCreatedDate < validDateTimeOffset)
        {
            throw new SignInAttemptIsInvalidException(userId, userName);
        }
    }
}
