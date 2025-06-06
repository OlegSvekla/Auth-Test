namespace IRLIX.Ef.Setup.Soft.Attributes;

public abstract class SoftPropertyAttribute : Attribute
{
    public abstract string PropertyName { get; }

    public abstract Type PropertyType { get; }
}
