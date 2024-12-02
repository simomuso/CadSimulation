using CadSimulation.Core.Models;
using CadSimulation.Core.Ports;

namespace CadSimulation.PersistenceAdapters.Repositories
{
    public class InMemoryRepository : IShapeRepository
    {
        private IEnumerable<IShape> _shapes = [];

        public async Task<IEnumerable<IShape>> ReadAsync()
        {
            return await Task.FromResult(_shapes);
        }

        public async Task WriteAsync(IEnumerable<IShape> shapes)
        {
            _shapes = shapes;
            await Task.CompletedTask;
        }
    }
}
