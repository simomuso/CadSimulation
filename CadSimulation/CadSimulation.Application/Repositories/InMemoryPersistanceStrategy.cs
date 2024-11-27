using CadSimulation.Application.Models;

namespace CadSimulation.Application.Repositories
{
    public class InMemoryPersistanceStrategy : IPersistanceStrategy
    {
        private IEnumerable<IShape> _shapes = [];

        public async Task<IEnumerable<IShape>> ExecuteReadAsync()
        {
            return await Task.FromResult(_shapes);
        }

        public async Task ExecuteWriteAsync(IEnumerable<IShape> shapes)
        {
            _shapes = shapes;
            await Task.CompletedTask;
        }
    }
}
