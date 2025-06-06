using FluentValidation.Results;
using IRLIX.Core.Attributes;
using IRLIX.Core.Exceptions;
using Microsoft.AspNetCore.Http;

namespace IRLIX.Web.Validation.FluentValidation.Exceptions;

[HttpResponseStatusCode(StatusCodes.Status400BadRequest)]
public class BadValidationException(
    IReadOnlyCollection<ValidationResult> badValidationResults,
    Exception? innerEx = null
    ) : DomainException(
        message: ErrorMessage,
        innerEx: innerEx)
{
    private const string ErrorMessage = "Bad validation result";
    public override int Code => (int)ExCodes.BadValidation;
    public IReadOnlyCollection<ValidationResult> BadValidationResults { get; } = badValidationResults;

    public static void ThrowWhenNotEmpty(
        IReadOnlyCollection<ValidationResult> badValidationResults)
    {
        if (badValidationResults.Any())
        {
            throw new BadValidationException(badValidationResults);
        }
    }
}
