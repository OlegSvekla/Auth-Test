namespace IRLIX.Web.Startups;

/// <summary>
/// Order service registration.
/// Use when need to override services from other startups
/// </summary>
public enum ServiceRegistrationOrderEnum
{
    Lowest,
    Lower,
    Medium,
    Higher,
    Highest
}
