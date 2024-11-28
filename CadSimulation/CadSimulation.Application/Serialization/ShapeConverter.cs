using CadSimulation.Application.Models.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CadSimulation.Application.Serialization
{
    public class ShapeConverter : JsonCreationConverter<ISerializableShape>
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected override ISerializableShape Create(Type objectType, JObject jObject)
        {
            var type = jObject["Type"]?.ToString();
            switch (type)
            {
                case "Triangle":
                    return new SerializableTriangle
                    {
                        Base = int.Parse(jObject["Base"]?.ToString()),
                        Height = int.Parse(jObject["Height"]?.ToString())
                    };
                case "Circle":
                    return new SerializableCircle
                    {
                        Radius = int.Parse(jObject["Radius"]?.ToString())
                    };
                case "Square":
                    return new SerializableSquare
                    {
                        Side = int.Parse(jObject["Side"]?.ToString())
                    };
                case "Rectangle":
                    return new SerializableRectangle
                    {
                        Height = int.Parse(jObject["Height"]?.ToString()),
                        Width = int.Parse(jObject["Width"]?.ToString())
                    };
            }

            return null!;
        }
    }
}


