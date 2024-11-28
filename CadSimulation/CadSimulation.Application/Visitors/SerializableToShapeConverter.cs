using CadSimulation.Application.Models;
using CadSimulation.Application.Models.Json;

namespace CadSimulation.Application.Visitors
{
    public class SerializableToShapeConverter : ISerializableShapeVisitor
    {
        public IShape ConvertedValue { get; private set; } = null!;

        public void Visit(SerializableCircle circle)
        {
            ConvertedValue = new Circle(circle.Radius);
        }

        public void Visit(SerializableRectangle rectangle)
        {
            ConvertedValue = new Rectangle(rectangle.Height, rectangle.Width);
        }

        public void Visit(SerializableTriangle triangle)
        {
            ConvertedValue = new Triangle(triangle.Base, triangle.Height);
        }

        public void Visit(SerializableSquare square)
        {
            ConvertedValue = new Square(square.Side);
        }
    }
}
