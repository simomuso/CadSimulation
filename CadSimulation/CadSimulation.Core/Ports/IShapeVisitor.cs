using CadSimulation.Core.Models;

public interface IShapeVisitor
{
    void Visit(Circle circle);
    void Visit(Rectangle rectangle);
    void Visit(Triangle triangle);
    void Visit(Square square);
}
