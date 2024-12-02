using System.Text.Json.Serialization;

namespace CadSimulation.Domain.Entities
{
    public interface ISerializableShape
    {
        [JsonPropertyName("Width")]
        string Type { get; }

        void Accept(ISerializableShapeVisitor visitor);
    }
}
