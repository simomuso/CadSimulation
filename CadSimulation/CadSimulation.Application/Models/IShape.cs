// See https://aka.ms/new-console-template for more information
namespace CadSimulation.Application.Models
{
    public interface IShape
    {
        void descr();
        double area();
        void Accept(IShapeVisitor visitor);
    }
}
