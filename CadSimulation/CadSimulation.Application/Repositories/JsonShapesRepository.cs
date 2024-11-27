using CadSimulation.Application.Models;
using CadSimulation.Application.Models.Json;
using CadSimulation.Application.Visitors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace CadSimulation.Application.Repositories
{
    internal class JsonShapesRepository : IShapesRepository
    {
        private readonly string _filePath;

        public JsonShapesRepository(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<IEnumerable<IShape>> GetAllAsync()
        {
            var shapes = new List<IShape>();
            var fileContent = await File.ReadAllTextAsync(_filePath);
            var serializableShapes = JsonConvert.DeserializeObject<IEnumerable<ISerializableShape>>(fileContent, new ShapeConverter());
            foreach(var serializableShape in serializableShapes)
            {
                var visitor = new SerializableShapeConverter();
                serializableShape.Accept(visitor);
                shapes.Add(visitor.ConvertedValue);
            }
            return shapes;
        }

        public async Task SaveAllAsync(IEnumerable<IShape> shapes)
        {
            var shapesToSerialize = new List<ISerializableShape>();
            foreach(var shape in shapes)
            {
                var visitor = new JsonShapeFormatter();
                shape.Accept(visitor);
                shapesToSerialize.Add(visitor.FormattedValue);
            }

            var serializedContent = JsonConvert.SerializeObject(shapesToSerialize);
            await File.WriteAllTextAsync(_filePath, serializedContent);
        }
        private class ShapeConverter : JsonCreationConverter<ISerializableShape>
        {
            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            protected override ISerializableShape Create(Type objectType, JObject jObject)
            {
                var type = jObject["Type"].ToString();
                switch (type)
                {
                    case "Triangle":
                        return new SerializableTriangle
                        {
                            Base = int.Parse(jObject["Base"].ToString()),
                            Height = int.Parse(jObject["Height"].ToString())
                        };
                    case "Circle":
                        return new SerializableCircle
                        {
                            Radius = int.Parse(jObject["Radius"].ToString())
                        };
                    case "Square":
                        return new SerializableSquare
                        {
                            Side = int.Parse(jObject["Side"].ToString())
                        };
                    case "Rectangle":
                        return new SerializableRectangle
                        {
                            Height = int.Parse(jObject["Height"].ToString()),
                            Width = int.Parse(jObject["Width"].ToString())
                        };
                }

                return null!;
            }
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
    }
}


