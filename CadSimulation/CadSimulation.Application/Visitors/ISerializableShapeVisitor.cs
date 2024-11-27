// See https://aka.ms/new-console-template for more information
using CadSimulation.Application.Models.Json;

internal interface ISerializableShapeVisitor
{
    void Visit(SerializableCircle circle);
    void Visit(SerializableRectangle rectangle);
    void Visit(SerializableTriangle triangle);
    void Visit(SerializableSquare square);
}