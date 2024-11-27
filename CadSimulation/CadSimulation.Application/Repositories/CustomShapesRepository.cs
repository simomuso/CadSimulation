using CadSimulation.Application.Models;

namespace CadSimulation.Application.Repositories
{
    internal class CustomShapesRepository : IShapesRepository
    {
        private readonly string _filePath;

        internal CustomShapesRepository(string filePath) 
        {
            _filePath = filePath;
        }

        public async Task<IEnumerable<IShape>> GetAllAsync()
        {
            var shapes = new List<IShape>();

            var lines = await File.ReadAllLinesAsync(_filePath);
            foreach (var line in lines)
            {
                var lineItems = line.Split(' ');
                switch (lineItems[0])
                {
                    case "S":
                        var side = int.Parse(lineItems[1]);
                        shapes.Add(new Square(side));
                        break;
                    case "R":
                        var rWidth = int.Parse(lineItems[1]);
                        var rHeight = int.Parse(lineItems[2]);
                        shapes.Add(new Rectangle(rHeight, rWidth));
                        break;
                    case "T":
                        var tBase = int.Parse(lineItems[1]);
                        var tHeight = int.Parse(lineItems[2]);
                        shapes.Add(new Triangle(tBase, tHeight));
                        break;
                    case "C":
                        var radius = int.Parse(lineItems[1]);
                        shapes.Add(new Circle(radius));
                        break;
                }
            }

            return shapes;
        }

        public async Task SaveAllAsync(IEnumerable<IShape> shapes)
        {
            var lines = new List<string>();
            foreach (var shape in shapes)
            {
                var formattedValueVisitor = new CustomShapeFormatter();
                shape.Accept(formattedValueVisitor);
                lines.Add(formattedValueVisitor.FormattedValue);
            }

            await File.WriteAllLinesAsync(_filePath, lines);
        }
    }
}
