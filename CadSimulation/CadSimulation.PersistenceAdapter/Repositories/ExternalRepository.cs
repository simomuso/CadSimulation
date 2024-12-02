using CadSimulation.Core.Models;
using CadSimulation.Core.Ports;

namespace CadSimulation.PersistenceAdapters.Repositories
{
    public class ExternalRepository : IShapeRepository
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _serviceUri;
        private readonly IShapeMapper _shapeMapper;

        public ExternalRepository(Uri serviceUri, IShapeMapper shapeMapper)
        {
            _httpClient = new HttpClient();
            _serviceUri = serviceUri;
            _shapeMapper = shapeMapper;
        }

        public async Task<IEnumerable<IShape>> ReadAsync()
        {
            var httpResponse = await _httpClient.GetAsync(_serviceUri);
            var responseBody = await httpResponse.Content.ReadAsStringAsync();
            return _shapeMapper.MapFrom(responseBody);
        }

        public async Task WriteAsync(IEnumerable<IShape> shapes)
        {
            var metadataToSend = _shapeMapper.MapTo(shapes);
            await _httpClient.PostAsync(_serviceUri, new StringContent(metadataToSend));
        }
    }
}
