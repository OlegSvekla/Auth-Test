using FluentValidation;

namespace IRLIX.Web.Models.Rqs.SignIns;

public sealed record SignMeInViaEmailBodyRq(
    string Email,
    string DeviceId
    );

public class SignMeInViaEmailBodyRqValidator
    : AbstractValidator<SignMeInViaEmailBodyRq>
{
    public SignMeInViaEmailBodyRqValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.DeviceId)
            .NotEmpty().WithMessage("Device ID is required.");
    }
}
