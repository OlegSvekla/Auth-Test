namespace IRLIX.L11n.Configs;

public sealed class L11nConfig
{
    public IReadOnlyCollection<string> SupportedCultures { get; set; }
        = [
            "en-US"
        ];

    public string DefaultCulture { get; set; } = "en-US";

    public string ResourcesPath { get; set; } = "Resources";
}
