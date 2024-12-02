using System.Text.Json.Serialization;

namespace CadSimulation.Core.Models
{
    public class SerializableTriangle : ISerializableShape
    {
        public SerializableTriangle() { }

        [JsonPropertyName("Height")]
        public int Height { get; set; }

        [JsonPropertyName("Base")]
        public int Base { get; set; }
        public string Type => "Triangle";
        void ISerializableShape.Accept(ISerializableShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
