using CadSimulation.Application.Models;
using CadSimulation.Application.Models.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CadSimulation.Application.Repositories
{
    public class LocalJsonPersistanceStrategy : IPersistanceStrategy
    {
        private readonly string _filePath;

        public LocalJsonPersistanceStrategy(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<IEnumerable<IShape>> ExecuteReadAsync()
        {
            var fileContent = await File.ReadAllTextAsync(_filePath);
            return Mappers.MapFromJsonFormat(fileContent);
        }

        public async Task ExecuteWriteAsync(IEnumerable<IShape> shapes)
        {
            var serializedContent = Mappers.MapToJsonFormat(shapes);
            await File.WriteAllTextAsync(_filePath, serializedContent);
        }
        
    }

    public class ShapeConverter : JsonCreationConverter<ISerializableShape>
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

    public abstract class JsonCreationConverter<T> : JsonConverter
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


