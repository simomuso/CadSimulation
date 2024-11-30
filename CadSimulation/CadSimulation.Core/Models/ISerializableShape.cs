using System.Text.Json.Serialization;

namespace CadSimulation.Core.Models
{
    public interface ISerializableShape
    {
        [JsonPropertyName("Width")]
        string Type { get; }

        void Accept(ISerializableShapeVisitor visitor);
    }
}
