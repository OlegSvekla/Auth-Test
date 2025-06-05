namespace IRLIX.Core.IRLIX.Web.Identity.Lockouts.Models;

public sealed class LockoutDto
{
    /// <summary>
    /// Gets or sets a flag indicating if the user could be locked out
    /// </summary>
    public bool Enabled { get; set; } = true;

    public DateTimeOffset? EndDate { get; set; }

    public string? Reason { get; set; } = default!;

    public DateTimeOffset? CreatedDate { get; set; } = default!;

    public Guid? CreatedByUserId { get; set; }

    public static LockoutDto CreateDefault(bool enabled)
        => new LockoutDto
        {
            Enabled = enabled
        };
}
