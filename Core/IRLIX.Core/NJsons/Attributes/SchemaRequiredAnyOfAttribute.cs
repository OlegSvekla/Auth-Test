using NJsonSchema;

namespace IRLIX.Core.NJsons.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
public class SchemaRequiredAnyOfAttribute(
    params string[] Values
    ) : Attribute, ISchemaClassAttribute, ISchemaPropertyAttribute
{
    public void Apply(JsonSchema schema)
    {
        foreach (var value in Values)
        {
            schema.AnyOf.Add(new JsonSchema { RequiredProperties = { value } });
        }
    }
}
