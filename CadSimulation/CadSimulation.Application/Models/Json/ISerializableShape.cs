using System.Text.Json.Serialization;

namespace CadSimulation.Application.Models.Json
{
    internal interface ISerializableShape
    {
        [JsonPropertyName("Width")]
        string Type { get; }

        void Accept(ISerializableShapeVisitor visitor);
    }
}
