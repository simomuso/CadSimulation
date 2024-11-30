using CadSimulation.Core.Models;

public class ShapeToCustomConverter : IShapeVisitor
{
    public string ConvertedValue { get; private set; } = null!;

    public void Visit(Circle circle)
    {
        ConvertedValue = $"C {circle?.Radius}";
    }

    public void Visit(Rectangle rectangle)
    {
        ConvertedValue = $"R {rectangle?.Width} {rectangle?.Height}";
    }

    public void Visit(Triangle triangle)
    {
        ConvertedValue = $"T {triangle?.Base} {triangle?.Height}";
    }

    public void Visit(Square square)
    {
        ConvertedValue = $"S {square?.Side}";
    }
}