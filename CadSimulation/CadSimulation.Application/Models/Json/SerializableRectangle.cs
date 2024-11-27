using System.Text.Json.Serialization;

namespace CadSimulation.Application.Models.Json
{
    public class SerializableRectangle : ISerializableShape
    {
        public SerializableRectangle() { }

        [JsonPropertyName("Width")]
        public int Width { get; set; }

        [JsonPropertyName("Height")]
        public int Height { get; set; }
        public string Type => "Rectangle"; 
        void ISerializableShape.Accept(ISerializableShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
