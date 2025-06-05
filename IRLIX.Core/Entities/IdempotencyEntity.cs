using IRLIX.Core.Ef.Models;

namespace IRLIX.Core.Entities;

/// <summary>
/// Idempotency ensures that operations can be retried without causing duplicate effects
/// It's TPH relationship
/// </summary>
public abstract class IdempotencyEntity : EntityCreatedUpdatedDates
{
    /// <summary>
    /// A unique key used to ensure that operations are idempotent. 
    /// This key helps to avoid processing the same request multiple times.
    /// </summary>
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The expiration date of the idempotency key. 
    /// After this date, the key is no longer valid for ensuring idempotency.
    /// Default TTL 24h
    /// </summary>
    public DateTimeOffset? IdempotencyKeyExpDate { get; set; }
}
