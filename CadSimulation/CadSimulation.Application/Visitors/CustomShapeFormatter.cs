// See https://aka.ms/new-console-template for more information
using CadSimulation.Application.Models;

public class CustomShapeFormatter : IShapeVisitor
{
    public string FormattedValue { get; private set; } = null!;

    public void Visit(Circle circle)
    {
        FormattedValue = $"C {circle?.Radius}";
    }

    public void Visit(Rectangle rectangle)
    {
        FormattedValue = $"R {rectangle?.Width} {rectangle?.Height}";
    }

    public void Visit(Triangle triangle)
    {
        FormattedValue = $"T {triangle?.Base} {triangle?.Height}";
    }

    public void Visit(Square square)
    {
        FormattedValue = $"S {square?.Side}";
    }
}