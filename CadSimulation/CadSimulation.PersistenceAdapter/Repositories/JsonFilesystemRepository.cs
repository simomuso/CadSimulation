using CadSimulation.Core.Ports;

namespace CadSimulation.PersistenceAdapters.Repositories
{
    public class JsonFilesystemRepository : FilesystemRepository
    {
        public JsonFilesystemRepository(string filePath, IShapeMapper shapeMapper) : base(filePath, shapeMapper)
        {
        }
    }
}


