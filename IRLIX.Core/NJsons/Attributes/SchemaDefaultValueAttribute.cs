using NJsonSchema;

namespace IRLIX.Core.NJsons.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class SchemaDefaultValueAttribute(
    string Value
    ) : Attribute, ISchemaPropertyAttribute
{
    public void Apply(JsonSchema schema)
        => schema.Default = Value;
}
