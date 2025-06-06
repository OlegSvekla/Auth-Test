using FluentValidation;

namespace IRLIX.Auth.Web.Models.Rqs.VerifyCodes;

public sealed record VerifyCodeByMeViaEmailBodyRq(
    string Email,
    string Code,
    string DeviceId
    );

public class VerifyCodeByMeViaEmailBodyRqValidator
    : AbstractValidator<VerifyCodeByMeViaEmailBodyRq>
{
    public VerifyCodeByMeViaEmailBodyRqValidator()
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
