using FluentValidation;

namespace IRLIX.Auth.Web.Models.Rqs.SignUps;

public sealed record SignMeUpBodyRq(
    string FirstName,
    string Phone,
    string Email
    );

public class SignMeUpBodyRqValidator
    : AbstractValidator<SignMeUpBodyRq>
{
    public SignMeUpBodyRqValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Length(Consts.MinLengthOfNames, Consts.MaxLengthOfNames)
            .WithMessage($"First name must be between {Consts.MinLengthOfNames} and {Consts.MaxLengthOfNames} characters.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(Consts.PhoneExpression).WithMessage("Phone number must be in international format starting with '+'.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
    }
}
