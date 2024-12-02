using CadSimulation.Core.Ports;

namespace CadSimulation.PersistenceAdapters.Repositories
{
    public class CustomFilesystemRepository : FilesystemRepository
    {
        public CustomFilesystemRepository(string filePath, IShapeMapper shapeMapper) : base(filePath, shapeMapper)
        {
        }
    }
}
