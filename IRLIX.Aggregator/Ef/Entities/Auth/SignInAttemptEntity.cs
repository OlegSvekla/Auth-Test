using IRLIX.Aggregator.Ef.Enums.Auth;
using IRLIX.Ef.Models;

namespace IRLIX.Aggregator.Ef.Entities.Auth;

public class SignInAttemptEntity : EntityCreatedDate
{
    public string DeviceId { get; set; } = default!;

    public UserSignInAttemptType Type { get; set; } = UserSignInAttemptType.None;

    public string Ip { get; set; } = default!;

    public string UserAgent { get; set; } = default!;

    public string? CodeHash { get; set; } = default!;

    public Guid UserId { get; set; } = default!;
    public UserEntity User { get; set; } = default!;

    public Guid? SessionId { get; set; }
    public SessionEntity? Session { get; set; }
}
