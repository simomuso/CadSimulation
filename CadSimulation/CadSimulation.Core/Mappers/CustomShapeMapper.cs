using CadSimulation.Core.Models;
using CadSimulation.Core.Ports;
using System.Text;

namespace CadSimulation.Core.Mappers
{
    public class CustomShapeMapper : IShapeMapper
    {
        public IEnumerable<IShape> MapFrom(string shapes)
        {
            var result = new List<IShape>();
            using var reader = new StringReader(shapes);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var lineItems = line.Split(' ');
                switch (lineItems[0])
                {
                    case "S":
                        var side = int.Parse(lineItems[1]);
                        result.Add(new Square(side));
                        break;
                    case "R":
                        var rWidth = int.Parse(lineItems[1]);
                        var rHeight = int.Parse(lineItems[2]);
                        result.Add(new Rectangle(rHeight, rWidth));
                        break;
                    case "T":
                        var tBase = int.Parse(lineItems[1]);
                        var tHeight = int.Parse(lineItems[2]);
                        result.Add(new Triangle(tBase, tHeight));
                        break;
                    case "C":
                        var radius = int.Parse(lineItems[1]);
                        result.Add(new Circle(radius));
                        break;
                }
            }

            return result;
        }

        public string MapTo(IEnumerable<IShape> shapes)
        {
            var sb = new StringBuilder();
            foreach (var shape in shapes)
            {
                var formattedValueVisitor = new ShapeToCustomConverter();
                shape.Accept(formattedValueVisitor);
                sb.AppendLine(formattedValueVisitor.ConvertedValue);
            }

            return sb.ToString();
        }
    }
}
