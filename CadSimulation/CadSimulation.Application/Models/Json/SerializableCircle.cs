using System.Text.Json.Serialization;

namespace CadSimulation.Application.Models.Json
{
    public class SerializableCircle : ISerializableShape
    {
        public SerializableCircle() { }

        [JsonPropertyName("Radius")]
        public int Radius { get; set; }
        public string Type => "Circle";

        void ISerializableShape.Accept(ISerializableShapeVisitor visitor)
        {
           visitor.Visit(this);
        }
    }
}
