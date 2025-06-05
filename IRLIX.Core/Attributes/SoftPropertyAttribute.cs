namespace IRLIX.Core.Attributes;

public abstract class SoftPropertyAttribute : Attribute
{
    public abstract string PropertyName { get; }

    public abstract Type PropertyType { get; }
}
