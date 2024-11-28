using CadSimulation.Application.Models;

namespace CadSimulation.Application.Repositories
{
    public interface IRepository
    {
        Task<IEnumerable<IShape>> ReadAsync(); 
        Task WriteAsync(IEnumerable<IShape> shapes);
    }
}
