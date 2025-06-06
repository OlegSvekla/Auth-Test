using IRLIX.Ef.Identity.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRLIX.Aggregator.Ef.Entities.Auth;

/// <summary>
/// User for auth processing.
/// Important: don't use this entity to set any fields from base identity entity,
/// just those fields which are necessary for user to be authenticated,
/// example, phone, email and others for 2FA. To save any details about user see
/// <see cref="ProfileEntity"/>
/// </summary>
public class UserEntity : EfIdentityUserEntity
{
    /// <summary>
    /// Current user's Id
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override Guid Id { get; set; }

    /// <summary>
    /// Signalize that user is account for testing
    /// </summary>
    public bool? Simulacrum { get; set; }

    /// <summary>
    /// Can be used instead of otp codes when not null.
    /// If field set, otp will not be sent to email or phone
    /// </summary>
    public string? HardcodedCode { get; set; }

    /// <summary>
    /// User’s roles.
    /// </summary>
    public IList<UserRoleEntity> UserRoles { get; set; } = [];

    /// <summary>
    /// User’s login attempts
    /// </summary>
    public IList<SignInAttemptEntity> UserSignInAttempts { get; set; } = [];

    /// <summary>
    /// User’s login attempts
    /// </summary>
    public IList<SessionEntity> Sessions { get; set; } = [];
}
