namespace IRLIX.Auth.Contracts.Commands.SignUps;

public sealed record SignMeUpCommand(
    string FirstName,
    string Phone,
    string Email
    ) : IMediatrCreateCommand
{
    public Guid Id { get; set; }
}
