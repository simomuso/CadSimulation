using CadSimulation.Application.Models;
using System.Text;

namespace CadSimulation.Application.Repositories
{
    public class LocalCustomPersistanceStrategy : IPersistanceStrategy
    {
        private readonly string _filePath;

        public LocalCustomPersistanceStrategy(string filePath) 
        {
            _filePath = filePath;
        }

        public async Task<IEnumerable<IShape>> ExecuteReadAsync()
        {
            var fileContent = await File.ReadAllTextAsync(_filePath);
            return Mappers.MapFromCustomFormat(fileContent);
        }

        public async Task ExecuteWriteAsync(IEnumerable<IShape> shapes)
        {
            var contentToWrite = Mappers.MapToCustomFormat(shapes);
            await File.WriteAllTextAsync(_filePath, contentToWrite);
        }
    }
}
