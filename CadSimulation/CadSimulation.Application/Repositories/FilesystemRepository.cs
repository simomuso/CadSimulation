using CadSimulation.Application.Models;

namespace CadSimulation.Application.Repositories
{
    public abstract class FilesystemRepository : IFilesystemRepository
    {
        private readonly string _filePath;

        public FilesystemRepository(string filePath) 
        {
            _filePath = filePath;
        }

        public abstract IEnumerable<IShape> MapFromFileFormat(string fileContent);
        public abstract string MapToFileFormat(IEnumerable<IShape> shapes);

        public async Task<IEnumerable<IShape>> ReadAsync()
        {
            var fileContent = await File.ReadAllTextAsync(_filePath);
            return MapFromFileFormat(fileContent);
        }

        public async Task WriteAsync(IEnumerable<IShape> shapes)
        {
            var serializedContent = MapToFileFormat(shapes);
            await File.WriteAllTextAsync(_filePath, serializedContent);
        }
    }
}


