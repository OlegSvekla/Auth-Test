using FluentValidation;

namespace IRLIX.Auth.Web.Models.Rqs.OtpVerifies;

public record VerifyConfirmByMeViaEmailBodyRq(
    string Email,
    string Code,
    string DeviceId
    );

public class VerifyConfirmByMeViaEmailBodyRqValidator
    : AbstractValidator<VerifyConfirmByMeViaEmailBodyRq>
{
    public VerifyConfirmByMeViaEmailBodyRqValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required.")
            .Length(Consts.VerifyCodeLength).WithMessage($"Code must be exactly {Consts.VerifyCodeLength} characters.");

        RuleFor(x => x.DeviceId)
            .NotEmpty().WithMessage("Device ID is required.");
    }
}
