using System.Text.Json.Serialization;

namespace CadSimulation.Application.Models.Json
{
    public class SerializableSquare : ISerializableShape
    {
        public SerializableSquare() { }

        [JsonPropertyName("Side")]
        public int Side { get; set; }
        public string Type => "Square";
        void ISerializableShape.Accept(ISerializableShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
