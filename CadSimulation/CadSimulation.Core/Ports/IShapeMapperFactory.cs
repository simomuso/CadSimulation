namespace CadSimulation.Core.Ports
{
    public interface IShapeMapperFactory
    {
        IShapeMapper Create(bool useJsonFormat);
    }
}
