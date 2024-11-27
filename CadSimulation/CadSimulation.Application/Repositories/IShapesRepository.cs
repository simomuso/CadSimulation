using CadSimulation.Application.Models;

namespace CadSimulation.Application.Repositories
{
    internal interface IShapesRepository
    {
        Task<IEnumerable<IShape>> GetAllAsync(); 
        Task SaveAllAsync(IEnumerable<IShape> shapes);
    }
}
