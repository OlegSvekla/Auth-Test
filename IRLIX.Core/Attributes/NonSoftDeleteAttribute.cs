namespace IRLIX.Core.Attributes;

/// <summary>
/// Restrict soft delete for entity. Necessary to use only if <see cref="DbConfig.SetSoftDeleteByDefault"/> is true
/// </summary>
public class NonSoftDeleteAttribute : SoftPropertyAttribute
{
    public override string PropertyName => Consts.SoftDeletePropertyName;

    public override Type PropertyType => Consts.SoftDeletePropertyType;
}
