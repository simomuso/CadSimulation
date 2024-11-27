// See https://aka.ms/new-console-template for more information
using CadSimulation.Application.Models;
internal interface IFilesystemShapeSerializerVisitor
{
    void Visit(Circle circle);
    void Visit(Rectangle rectangle);
    void Visit(Triangle triangle);
    void Visit(Square square);
}

internal class FilesystemShapeSerializer : IFilesystemShapeSerializerVisitor
{
    internal string SerializedValue { get; private set; } = null!;

    public void Visit(Circle circle)
    {
        SerializedValue = $"C {circle?.Radius}";
    }

    public void Visit(Rectangle rectangle)
    {
        SerializedValue = $"R {rectangle?.Width} {rectangle?.Height}";
    }

    public void Visit(Triangle triangle)
    {
        SerializedValue = $"T {triangle?.Base} {triangle?.Height}";
    }

    public void Visit(Square square)
    {
        SerializedValue = $"S {square?.Side}";
    }
}