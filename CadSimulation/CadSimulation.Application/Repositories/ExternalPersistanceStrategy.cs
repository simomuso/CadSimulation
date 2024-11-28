using CadSimulation.Application.Models;
using CadSimulation.Application.Models.Json;
using CadSimulation.Application.Visitors;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CadSimulation.Application.Repositories
{
    public class ExternalPersistanceStrategy : IPersistanceStrategy
    {
        private readonly Uri _serviceUri;
        private readonly bool _useJsonFormat;
        private readonly HttpClient _httpClient = new();

        public ExternalPersistanceStrategy(Uri serviceUri, bool useJsonFormat) 
        {
            _serviceUri = serviceUri;
            _useJsonFormat = useJsonFormat;
        }

        public async Task<IEnumerable<IShape>> ExecuteReadAsync()
        {
            var httpResponse = await _httpClient.GetAsync(_serviceUri);
            var respondeBody = await httpResponse.Content.ReadAsStringAsync();
            if (_useJsonFormat)
                return Mappers.MapFromJsonFormat(respondeBody);

            return Mappers.MapFromCustomFormat(respondeBody);
        }

        public async Task ExecuteWriteAsync(IEnumerable<IShape> shapes)
        {
            string contentToSend;

            if (_useJsonFormat)
                contentToSend = Mappers.MapToJsonFormat(shapes);
            else
                contentToSend = Mappers.MapToCustomFormat(shapes);

            await _httpClient.PostAsync(_serviceUri, new StringContent(contentToSend));

        }
    }
}
