// See https://aka.ms/new-console-template for more information
using CadSimulation.Application.Models;

internal interface IShapeVisitor
{
    void Visit(Circle circle);
    void Visit(Rectangle rectangle);
    void Visit(Triangle triangle);
    void Visit(Square square);
}
