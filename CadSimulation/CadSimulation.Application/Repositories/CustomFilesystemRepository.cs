using CadSimulation.Application.Models;
using CadSimulation.Application.Serialization;

namespace CadSimulation.Application.Repositories
{
    public class CustomFilesystemRepository : FilesystemRepository
    {
        private readonly IShapeFormatMapper _shapeFormatMapper;

        public CustomFilesystemRepository(string filePath, 
            IShapeFormatMapper shapeFormatMapper) : base(filePath)
        {
            _shapeFormatMapper = shapeFormatMapper;
        }

        public override IEnumerable<IShape> MapFromFileFormat(string fileContent)
        {
            return _shapeFormatMapper.MapFromCustomFormat(fileContent);
        }

        public override string MapToFileFormat(IEnumerable<IShape> shapes)
        {
            return _shapeFormatMapper.MapToCustomFormat(shapes);
        }
    }
}
