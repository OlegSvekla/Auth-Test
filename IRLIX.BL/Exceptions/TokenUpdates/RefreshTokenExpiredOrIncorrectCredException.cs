using IRLIX.Core.Attributes;
using IRLIX.Core.Exceptions;
using System.Diagnostics.CodeAnalysis;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IRLIX.BL.Exceptions.TokenUpdates;

[HttpResponseStatusCode(Status401Unauthorized)]
public class RefreshTokenExpiredOrIncorrectCredException(
    Guid? userId = null,
    string? userName = null,
    Exception? innerEx = null
    ) : DomainException(
        message: ErrorMessage,
        innerEx: innerEx)
{
    private const string ErrorMessage = "Session expired";
    public override int Code => (int)ExCodes.UserHasNotBeenCreated;
    public string? UserName { get; } = userName;
    public Guid? UserId { get; } = userId;

    public static void ThrowWhenSessionNotExist<T>([NotNull] T? session)
    {
        if (session == null)
        {
            throw new RefreshTokenExpiredOrIncorrectCredException();
        }
    }

    public static void ThrowWhenDeviceIncorrect(
        string sessionDeviceId,
        string commandDeviceId,
        Guid userId,
        string userName)
    {
        if (!string.Equals(sessionDeviceId, commandDeviceId, StringComparison.OrdinalIgnoreCase))
        {
            throw new RefreshTokenExpiredOrIncorrectCredException(userId, userName);
        }
    }

    public static void ThrowWhenSessionExpired(
        DateTimeOffset sessionExpiresAt,
        DateTimeOffset currentDateTime,
        Guid userId,
        string userName)
    {
        if (sessionExpiresAt < currentDateTime)
        {
            throw new RefreshTokenExpiredOrIncorrectCredException(userId, userName);
        }
    }
}
