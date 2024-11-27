// See https://aka.ms/new-console-template for more information
namespace CadSimulation.Application.Models
{
    internal class Triangle : IShape
    {
        internal int Base { get; }
        internal int Height { get; }

        public Triangle(int b, int h)
        {
            Base = b;
            Height = h;
        }
        public void Accept(IFilesystemShapeSerializerVisitor visitor)
        {
            visitor.Visit(this);
        }

        double IShape.area()
        {
            return Base * Height / 2;
        }
        void IShape.descr()
        {
            Console.WriteLine($"Triangle, base: {Base}, height: {Height}");
        }
    }
}
