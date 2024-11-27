// See https://aka.ms/new-console-template for more information
namespace CadSimulation.Application.Models
{
    public class Circle : IShape
    {
        public int Radius { get; }

        public Circle(int radius)
        {
            Radius = radius;
        }

        double IShape.area()
        {
            return Radius * Radius * 3.1416;
        }

        void IShape.descr()
        {
            Console.WriteLine($"Circle, radius: {Radius}");
        }

        public void Accept(IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
