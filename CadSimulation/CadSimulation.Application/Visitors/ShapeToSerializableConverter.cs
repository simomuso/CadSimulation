// See https://aka.ms/new-console-template for more information
using CadSimulation.Application.Models;
using CadSimulation.Application.Models.Json;

public class ShapeToSerializableConverter : IShapeVisitor
{
    public ISerializableShape ConvertedValue { get; private set; } = null!;

    public void Visit(Circle circle)
    {
        ConvertedValue = new SerializableCircle
        {
            Radius = circle.Radius
        };
    }

    public void Visit(Rectangle rectangle)
    {
        ConvertedValue = new SerializableRectangle
        {
            Height = rectangle.Height,
            Width = rectangle.Width
        };
    }

    public void Visit(Triangle triangle)
    {
        ConvertedValue = new SerializableTriangle
        {
            Base = triangle.Base,
            Height = triangle.Height
        };
    }

    public void Visit(Square square)
    {
        ConvertedValue = new SerializableSquare
        {
            Side = square.Side
        };
    }
}