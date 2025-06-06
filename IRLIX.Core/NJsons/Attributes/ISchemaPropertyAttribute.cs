using NJsonSchema;

namespace IRLIX.Core.NJsons.Attributes;

public interface ISchemaPropertyAttribute
{
    void Apply(JsonSchema schema);
}
