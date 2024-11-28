﻿using CadSimulation.Application.Models;
using CadSimulation.Application.Models.Json;
using CadSimulation.Application.Visitors;
using Newtonsoft.Json;
using System.Text;

namespace CadSimulation.Application.Serialization
{
    public interface IShapeFormatMapper
    {
        IEnumerable<IShape> MapFromCustomFormat(string shapes);
        IEnumerable<IShape> MapFromJsonFormat(string shapes);
        string MapToCustomFormat(IEnumerable<IShape> shapes);
        string MapToJsonFormat(IEnumerable<IShape> shapes);
    }

    public class ShapeFormatMapper : IShapeFormatMapper
    {
        public IEnumerable<IShape> MapFromJsonFormat(string shapes)
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

        public string MapToJsonFormat(IEnumerable<IShape> shapes)
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

        public IEnumerable<IShape> MapFromCustomFormat(string shapes)
        {
            var result = new List<IShape>();
            using var reader = new StringReader(shapes);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var lineItems = line.Split(' ');
                switch (lineItems[0])
                {
                    case "S":
                        var side = int.Parse(lineItems[1]);
                        result.Add(new Square(side));
                        break;
                    case "R":
                        var rWidth = int.Parse(lineItems[1]);
                        var rHeight = int.Parse(lineItems[2]);
                        result.Add(new Rectangle(rHeight, rWidth));
                        break;
                    case "T":
                        var tBase = int.Parse(lineItems[1]);
                        var tHeight = int.Parse(lineItems[2]);
                        result.Add(new Triangle(tBase, tHeight));
                        break;
                    case "C":
                        var radius = int.Parse(lineItems[1]);
                        result.Add(new Circle(radius));
                        break;
                }
            }

            return result;
        }

        public string MapToCustomFormat(IEnumerable<IShape> shapes)
        {
            var sb = new StringBuilder();
            foreach (var shape in shapes)
            {
                var formattedValueVisitor = new ShapeToCustomConverter();
                shape.Accept(formattedValueVisitor);
                sb.AppendLine(formattedValueVisitor.ConvertedValue);
            }

            return sb.ToString();
        }
    }
}