using IRLIX.Core.Ef.Models;
using IRLIX.Core.Entities;
using IRLIX.Core.Enums;

namespace IRLIX.Core.Identity;

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
