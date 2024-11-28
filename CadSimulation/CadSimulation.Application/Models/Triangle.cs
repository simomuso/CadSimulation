// See https://aka.ms/new-console-template for more information
namespace CadSimulation.Application.Models
{
    public class Triangle : IShape
    {
        public int Base { get; }
        public int Height { get; }

        public Triangle(int b, int h)
        {
            Base = b;
            Height = h;
        }

        double IShape.area()
        {
            return Base * Height / 2;
        }
        void IShape.descr()
        {
            Console.WriteLine($"Triangle, base: {Base}, height: {Height}");
        }
        public void Accept(IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
