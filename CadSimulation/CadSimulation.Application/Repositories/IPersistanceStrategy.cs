using CadSimulation.Application.Models;

namespace CadSimulation.Application.Repositories
{
    public interface IPersistanceStrategy
    {
        Task<IEnumerable<IShape>> ExecuteReadAsync(); 
        Task ExecuteWriteAsync(IEnumerable<IShape> shapes);
    }
}
