// See https://aka.ms/new-console-template for more information
namespace CadSimulation.Application.Models
{
    internal class Square : IShape
    {
        internal int Side { get; }

        public Square(int side)
        {
            Side = side;
        }

        double IShape.area()
        {
            return Side * Side;
        }

        void IShape.descr()
        {
            Console.WriteLine($"Square, side: {Side}");
        }
        public void Accept(IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
