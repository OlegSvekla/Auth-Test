namespace IRLIX.IpMapping.Models;

public record FoundLocation(
    string CountryIsoCode,
    string? RegionIsoCode = null,
    string? City = null
    );
