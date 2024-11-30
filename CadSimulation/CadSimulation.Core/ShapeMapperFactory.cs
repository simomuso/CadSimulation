using CadSimulation.Core.Mappers;
using CadSimulation.Core.Ports;

namespace CadSimulation.Core
{
    public class ShapeMapperFactory : IShapeMapperFactory
    {
        public IShapeMapper Create(bool useJsonFormat)
        {
            return useJsonFormat ?
                new JsonShapeMapper() :
                new CustomShapeMapper();
        }
    }
}
