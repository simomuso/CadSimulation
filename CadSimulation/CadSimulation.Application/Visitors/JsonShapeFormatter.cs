// See https://aka.ms/new-console-template for more information
using CadSimulation.Application.Models;
using CadSimulation.Application.Models.Json;

internal class JsonShapeFormatter : IShapeVisitor
{
    internal ISerializableShape FormattedValue { get; private set; } = null!;

    public void Visit(Circle circle)
    {
        FormattedValue = new SerializableCircle
        {
            Radius = circle.Radius
        };
    }

    public void Visit(Rectangle rectangle)
    {
        FormattedValue = new SerializableRectangle
        {
            Height = rectangle.Height,
            Width = rectangle.Width
        };
    }

    public void Visit(Triangle triangle)
    {
        FormattedValue = new SerializableTriangle
        {
            Base = triangle.Base,
            Height = triangle.Height
        };
    }

    public void Visit(Square square)
    {
        FormattedValue = new SerializableSquare
        {
            Side = square.Side
        };
    }
}