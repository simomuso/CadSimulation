using System.Text.Json.Serialization;

namespace CadSimulation.Application.Models.Json
{
    public interface ISerializableShape
    {
        [JsonPropertyName("Width")]
        string Type { get; }

        void Accept(ISerializableShapeVisitor visitor);
    }
}
