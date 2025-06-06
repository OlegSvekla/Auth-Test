using IRLIX.Auth.Contracts.Commands.SignUps;
using IRLIX.BL.Shared.Modifiers.Creators;
using IRLIX.BL.Shared.Modifiers.Validators.Users;
using IRLIX.Mq.Local.MediatR.Handlers;

namespace IRLIX.BL.Handlers.Commands;

public class SignMeUpCommandHandler(
    IUserWithSameEmailExistValidator userWithSameEmailExistValidator,
    IUserCreator userCreator
    ) : MediatrCommandHandler<SignMeUpCommand>
{
    public override async ValueTask HandleAsync(
        SignMeUpCommand command,
        CancellationToken ct)
    {
        await userWithSameEmailExistValidator.ValidateAsync(command.Email, ct);
        var createdUser = await userCreator.CreateAsync(command.Phone, command.Email, ct);

        command.Id = createdUser.Id;
    }
}
