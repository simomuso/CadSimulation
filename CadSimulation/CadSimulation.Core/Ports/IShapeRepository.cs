using CadSimulation.Core.Models;

namespace CadSimulation.Core.Ports
{
    public interface IShapeRepository
    {
        Task<IEnumerable<IShape>> ReadAsync();
        Task WriteAsync(IEnumerable<IShape> shapes);
    }
}
