namespace IRLIX.Aggregator.Ef.Configs;

public sealed class AggregatorEfConfig
{
    /// <summary>
    /// Default admin email, which should be seeded
    /// </summary>
    public string? DefaultAdminEmail { get; init; }

    /// <summary>
    /// Default admin password, which should be seeded
    /// </summary>
    public string? DefaultAdminHardcodedCode { get; init; }
}
