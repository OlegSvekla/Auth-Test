namespace IRLIX.Ef.Configs;

public class DbConfig
{
    public string ConnectionString { get; init; } = default!;

    public bool SetSoftDeleteByDefault { get; init; } = true;
}
