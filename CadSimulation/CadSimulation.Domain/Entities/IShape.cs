// See https://aka.ms/new-console-template for more information
namespace CadSimulation.Domain.Entities
{
    public interface IShape
    {
        void descr();
        double area();
        void Accept(IShapeVisitor visitor);
    }
}
