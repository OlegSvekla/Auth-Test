using IRLIX.Core.Attributes;
using IRLIX.Core.Exceptions;
using IRLIX.Web.Identity.Lockouts.Models;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IRLIX.Web.Identity.Exceptions;

[HttpResponseStatusCode(Status423Locked)]
public class UserLockedOutException(
    string message,
    LockoutDto lockout,
    Exception? innerEx = null
    ) : DomainException(
        message: message,
        innerEx: innerEx)
{
    public override int Code => (int)ExCodes.UserLockedOut;
    public LockoutDto Lockout { get; } = lockout;

    public static void ThrowIfLockoutEndDateFound(LockoutDto lockout)
    {
        if (lockout.EndDate.HasValue && lockout.Enabled)
        {
            var lockoutEndDate = lockout.EndDate.Value;
            throw new UserLockedOutException($"Account locked until {lockoutEndDate}", lockout);
        }
    }
}
