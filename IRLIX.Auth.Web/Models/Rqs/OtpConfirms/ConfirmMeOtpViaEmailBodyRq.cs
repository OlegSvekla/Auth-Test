using FluentValidation;

namespace IRLIX.Auth.Web.Models.Rqs.OtpConfirms;

public record ConfirmMeOtpViaEmailBodyRq(
    string Email,
    string DeviceId
    );

public class ConfirmMeOtpViaEmailBodyRqValidator
    : AbstractValidator<ConfirmMeOtpViaEmailBodyRq>
{
    public ConfirmMeOtpViaEmailBodyRqValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.DeviceId)
            .NotEmpty().WithMessage("Device ID is required.");
    }
}
