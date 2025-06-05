using IRLIX.Core.Ef.Models;
using IRLIX.Core.Identity;
using Microsoft.AspNetCore.Identity;

namespace IRLIX.Core.Entities;

public class SessionEntity : EntityCreatedDate
{
    public string DeviceId { get; set; } = default!;

    public string Ip { get; set; } = default!;

    public string UserAgent { get; set; } = default!;

    /// <summary>
    /// Gets the refresh token.
    /// </summary>
    /// <value>
    /// The refresh token.
    /// </value>
    [ProtectedPersonalData]
    public string RefreshToken { get; set; } = default!;

    /// <summary>
    /// Gets or sets the expiration time.
    /// If it equals default DateTimeOffset it means user sign out or received a new token in related session
    /// </summary>
    /// <value>
    /// The expiration time.
    /// </value>
    public DateTimeOffset RefreshTokenExpiresAt { get; set; }

    public Guid UserId { get; set; } = default!;
    public UserEntity User { get; set; } = default!;

    public SignInAttemptEntity? SignInAttempt { get; set; }

    /// <summary>
    /// Session which refresh token has been used to create a new session
    /// </summary>
    public Guid? RelatedSessionId { get; set; }
}
