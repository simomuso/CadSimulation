using CadSimulation.Core.Models;

namespace CadSimulation.Core.Ports
{
    public interface IShapeMapper
    {
        IEnumerable<IShape> MapFrom(string shapes);
        string MapTo(IEnumerable<IShape> shapes);
    }
}
