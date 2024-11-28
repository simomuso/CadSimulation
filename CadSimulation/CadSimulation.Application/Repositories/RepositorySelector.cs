using CadSimulation.Application.Serialization;

namespace CadSimulation.Application.Repositories
{
    public class RepositorySelector : IRepositorySelector
    {
        private readonly IShapeFormatMapper _shapeFormatMapper;

        public RepositorySelector(IShapeFormatMapper shapeFormatMapper) 
        {
            _shapeFormatMapper = shapeFormatMapper;
        }

        public IRepository SelectRepository(ApplicationOptions options)
        {
            // If no persistance is selected, use in memory persistance
            if (string.IsNullOrWhiteSpace(options.FilesystemPath) && options.ServiceUri == null)
                return new InMemoryRepository();

            // If local persistence is configured and json format is selected, use it
            if(!string.IsNullOrWhiteSpace(options.FilesystemPath) && options.UseJsonFormat)
                return new JsonFilesystemRepository(options.FilesystemPath, _shapeFormatMapper);

            // If local persistence is configured and no json format is selected, use custom format
            if (!string.IsNullOrWhiteSpace(options.FilesystemPath) && !options.UseJsonFormat)
                return new CustomFilesystemRepository(options.FilesystemPath, _shapeFormatMapper);

            return new ExternalRepository(options.ServiceUri, options.UseJsonFormat, _shapeFormatMapper);
        }
    }

    public interface IRepositorySelector
    {
        IRepository SelectRepository(ApplicationOptions options);
    }
}
