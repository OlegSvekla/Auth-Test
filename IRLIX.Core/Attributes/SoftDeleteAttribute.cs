namespace IRLIX.Core.Attributes;

/// <summary>
/// Add soft delete for entity: nullable deleted date property, where null means entity was not deleted
/// otherwise when date was set means date when entity was removed and has to be ignored for most cases
/// </summary>
public class SoftDeleteAttribute : SoftPropertyAttribute
{
    public override string PropertyName => Consts.SoftDeletePropertyName;

    public override Type PropertyType => Consts.SoftDeletePropertyType;
}
