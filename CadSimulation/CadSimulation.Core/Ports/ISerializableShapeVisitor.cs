using CadSimulation.Core.Models;

public interface ISerializableShapeVisitor
{
    void Visit(SerializableCircle circle);
    void Visit(SerializableRectangle rectangle);
    void Visit(SerializableTriangle triangle);
    void Visit(SerializableSquare square);
}