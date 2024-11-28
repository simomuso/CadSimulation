using CadSimulation.Application.Models;
using CadSimulation.Application.Serialization;

namespace CadSimulation.Application.Repositories
{
    public class JsonFilesystemRepository : FilesystemRepository
    {
        private readonly IShapeFormatMapper _shapeFormatMapper;

        public JsonFilesystemRepository(string filePath,
            IShapeFormatMapper shapeFormatMapper) : base(filePath)
        {
            _shapeFormatMapper = shapeFormatMapper;
        }

        public override IEnumerable<IShape> MapFromFileFormat(string fileContent)
        {
            return _shapeFormatMapper.MapFromJsonFormat(fileContent);
        }

        public override string MapToFileFormat(IEnumerable<IShape> shapes)
        {
            return _shapeFormatMapper.MapToJsonFormat(shapes);
        }
    }
}


