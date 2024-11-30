using CadSimulation.Core.Models;
using CadSimulation.Core.Ports;

namespace CadSimulation.Application.Services
{
    public class PersistenceService : IPersistenceService
    {
        private readonly PersistenceServiceOptions _options;
        private readonly IShapeRepositoryFactory _shapesRepositoryFactory;

        public PersistenceService(PersistenceServiceOptions options,
            IShapeRepositoryFactory shapesRepositoryFactory)
        {
            _options = options;
            _shapesRepositoryFactory = shapesRepositoryFactory;
        }

        public async Task<IEnumerable<IShape>> ReadAsync()
        {
            return await _shapesRepositoryFactory.Create(_options.FilesystemPath, _options.ServiceUri, _options.UseJsonFormat).ReadAsync();
        }

        public async Task WriteAsync(IEnumerable<IShape> shapes)
        {
            var repository = _shapesRepositoryFactory.Create(_options.FilesystemPath, _options.ServiceUri, _options.UseJsonFormat);
            await repository.WriteAsync(shapes);
        }
    }
}
