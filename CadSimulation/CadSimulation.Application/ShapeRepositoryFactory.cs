using CadSimulation.Core.Ports;
using CadSimulation.PersistenceAdapters.Repositories;

namespace CadSimulation.Application
{
    public class ShapeRepositoryFactory : IShapeRepositoryFactory
    {
        private readonly IShapeMapperFactory _shapeMapperFactory;

        public ShapeRepositoryFactory(IShapeMapperFactory shapeMapperFactory) 
        {
            _shapeMapperFactory = shapeMapperFactory;
        }

        public IShapeRepository Create(string filePath, Uri? serviceUri, bool useJsonFormat)
        {
            if (string.IsNullOrWhiteSpace(filePath) && serviceUri == null)
                return new InMemoryRepository();

            var mapper = _shapeMapperFactory.Create(useJsonFormat);

            if (!string.IsNullOrEmpty(filePath) && useJsonFormat)
                return new JsonFilesystemRepository(filePath, mapper);

            if (!string.IsNullOrEmpty(filePath) && !useJsonFormat)
                return new CustomFilesystemRepository(filePath, mapper);

            return new ExternalRepository(serviceUri, mapper);
        }
    }
}
