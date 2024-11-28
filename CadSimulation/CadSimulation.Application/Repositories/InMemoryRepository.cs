using CadSimulation.Application.Models;

namespace CadSimulation.Application.Repositories
{
    public class InMemoryRepository : IRepository
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
