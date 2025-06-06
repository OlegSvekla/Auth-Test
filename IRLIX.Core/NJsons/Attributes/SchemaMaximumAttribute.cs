using NJsonSchema;

namespace IRLIX.Core.NJsons.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class SchemaMaximumAttribute(
    decimal Value
    ) : Attribute, ISchemaPropertyAttribute
{
    public void Apply(JsonSchema schema)
        => schema.Maximum = Value;
}
