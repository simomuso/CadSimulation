using CadSimulation.Application.Models;

namespace CadSimulation.Application.Repositories
{
    public interface IFilesystemRepository : IRepository
    {
        string MapToFileFormat(IEnumerable<IShape> shapes);
        IEnumerable<IShape> MapFromFileFormat(string fileContent);
    }
}
