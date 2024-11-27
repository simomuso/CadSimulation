using CadSimulation.Application.Models;

namespace CadSimulation.Application.Repositories
{
    public class ExternalPersistanceStrategy : IPersistanceStrategy
    {
        private readonly Uri _serviceUri;
        private readonly bool _useJsonFormat;

        public ExternalPersistanceStrategy(Uri serviceUri, bool useJsonFormat) 
        {
            _serviceUri = serviceUri;
            _useJsonFormat = useJsonFormat;
        }

        public Task<IEnumerable<IShape>> ExecuteReadAsync()
        {
            throw new NotImplementedException();
        }

        public Task ExecuteWriteAsync(IEnumerable<IShape> shapes)
        {
            throw new NotImplementedException();
        }
    }
}
