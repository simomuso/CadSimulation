// See https://aka.ms/new-console-template for more information
namespace CadSimulation.Application.Models
{
    internal class Rectangle : IShape
    {
        internal int Height { get; }
        internal int Width { get; }

        public Rectangle(int height, int witdh)
        {
            Height = height;
            Width = witdh;
        }

        public void Accept(IFilesystemShapeSerializerVisitor visitor)
        {
            visitor.Visit(this);
        }

        double IShape.area()
        {
            return Height * Width;
        }

        void IShape.descr()
        {
            Console.WriteLine($"Rectangle, height: {Height}, width: {Width}");
        }
    }
}
