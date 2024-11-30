using CadSimulation.Core.Models;
using CadSimulation.Core.Ports;
using CadSimulation.Core.Visitors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CadSimulation.Core.Mappers
{
    public class JsonShapeMapper : IShapeMapper
    {
        public IEnumerable<IShape> MapFrom(string shapes)
        {
            var result = new List<IShape>();
            var serializableShapes = JsonConvert.DeserializeObject<IEnumerable<ISerializableShape>>(shapes, new ShapeConverter());
            foreach (var serializableShape in serializableShapes)
            {
                var visitor = new SerializableToShapeConverter();
                serializableShape.Accept(visitor);
                result.Add(visitor.ConvertedValue);
            }
            return result;
        }

        public string MapTo(IEnumerable<IShape> shapes)
        {
            var shapesToSerialize = new List<ISerializableShape>();
            foreach (var shape in shapes)
            {
                var visitor = new ShapeToSerializableConverter();
                shape.Accept(visitor);
                shapesToSerialize.Add(visitor.ConvertedValue);
            }

            return JsonConvert.SerializeObject(shapesToSerialize);
        }

        private abstract class JsonCreationConverter<T> : JsonConverter
        {
            protected abstract T Create(Type objectType, JObject jObject);

            public override bool CanConvert(Type objectType)
            {
                return typeof(T).IsAssignableFrom(objectType);
            }

            public override bool CanWrite
            {
                get { return false; }
            }

            public override object ReadJson(JsonReader reader,
                                            Type objectType,
                                             object existingValue,
                                             JsonSerializer serializer)
            {
                JObject jObject = JObject.Load(reader);
                T target = Create(objectType, jObject);
                serializer.Populate(jObject.CreateReader(), target);
                return target;
            }
        }

        private class ShapeConverter : JsonCreationConverter<ISerializableShape>
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
}
