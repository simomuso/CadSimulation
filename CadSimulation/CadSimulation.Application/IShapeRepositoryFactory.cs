using CadSimulation.Core.Ports;

namespace CadSimulation.Application
{
    public interface IShapeRepositoryFactory
    {
        IShapeRepository Create(string filePath, Uri? serviceUri, bool useJsonFormat);
    }
}
