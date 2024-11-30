using CadSimulation.Core.Models;
using CadSimulation.Core.Ports;

namespace CadSimulation.PersistenceAdapters.Repositories
{
    public abstract class FilesystemRepository : IShapeRepository
    {
        private readonly string _filePath;
        private readonly IShapeMapper _shapeMapper;

        public FilesystemRepository(string filePath,
            IShapeMapper shapeMapper)
        {
            _filePath = filePath;
            _shapeMapper = shapeMapper;
        }

        public async Task<IEnumerable<IShape>> ReadAsync()
        {
            var fileContent = await File.ReadAllTextAsync(_filePath);
            return _shapeMapper.MapFrom(fileContent);
        }

        public async Task WriteAsync(IEnumerable<IShape> shapes)
        {
            var serializedContent = _shapeMapper.MapTo(shapes);
            await File.WriteAllTextAsync(_filePath, serializedContent);
        }
    }
}


