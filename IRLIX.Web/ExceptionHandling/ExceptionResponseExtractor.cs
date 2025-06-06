using ShuttleX.Core.Exceptions;
using ShuttleX.Core.General;
using ShuttleX.Web.Identity.Exceptions;
using ShuttleX.Web.Models.Rss.Errors;
using ShuttleX.Web.Validation.FluentValidation.Exceptions;

namespace ShuttleX.Web.ExceptionHandling;

public interface IExceptionResponseExtractor
{
    object Extract(Exception ex);
}

public class ExceptionResponseExtractor : IExceptionResponseExtractor
{
    public object Extract(Exception ex)
    {
        int? code = ex is DomainException domainEx
            ? domainEx.Code
            : null;

        var rs = GenerateRs(code, ex);
        return rs;
    }

    private static object GenerateRs(int? code, Exception ex)
        => ex switch
        {
            UserLockedOutException lockedOutEx => new UserLockedOutErrorRs(
                Code: code,
                LockoutEndDate: lockedOutEx.Lockout.EndDate.GetValueOrDefault(),
                LockoutReason: lockedOutEx.Lockout.Reason.GetValue()),
            BadValidationException badValidationEx => badValidationEx.BadValidationResults
                .SelectMany(result => result.Errors)
                .Select(error => new FieldErrorRs(
                    Code: null, //error.ErrorCode,
                    Message: error.ErrorMessage,
                    Field: error.PropertyName))
                .ToArray(),
            _ => new MessageErrorRs(code, ex.Message)
        };
}
