// See https://aka.ms/new-console-template for more information
namespace CadSimulation.Core.Models
{
    public interface IShape
    {
        void descr();
        double area();
        void Accept(IShapeVisitor visitor);
    }
}
