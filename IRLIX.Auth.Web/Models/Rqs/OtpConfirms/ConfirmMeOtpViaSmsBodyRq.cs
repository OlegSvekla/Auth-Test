using FluentValidation;

namespace IRLIX.Auth.Web.Models.Rqs.OtpConfirms;

public record ConfirmMeOtpViaSmsBodyRq(
    string Phone,
    string DeviceId
    );

public class ConfirmMeOtpViaSmsBodyRqValidator
    : AbstractValidator<ConfirmMeOtpViaSmsBodyRq>
{
    public ConfirmMeOtpViaSmsBodyRqValidator()
    {
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(Consts.PhoneExpression).WithMessage("Phone number must be in international format starting with '+'.");

        RuleFor(x => x.DeviceId)
            .NotEmpty().WithMessage("Device ID is required.");
    }
}
