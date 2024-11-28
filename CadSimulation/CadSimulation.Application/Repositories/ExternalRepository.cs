using CadSimulation.Application.Models;
using CadSimulation.Application.Models.Json;
using CadSimulation.Application.Serialization;
using CadSimulation.Application.Visitors;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CadSimulation.Application.Repositories
{
    public class ExternalRepository : IRepository
    {
        private readonly Uri _serviceUri;
        private readonly bool _useJsonFormat;
        private readonly IShapeFormatMapper _shapeFormatMapper;
        private readonly HttpClient _httpClient = new();

        public ExternalRepository(Uri serviceUri, 
            bool useJsonFormat,
            IShapeFormatMapper shapeFormatMapper) 
        {
            _serviceUri = serviceUri;
            _useJsonFormat = useJsonFormat;
            _shapeFormatMapper = shapeFormatMapper;
        }

        public async Task<IEnumerable<IShape>> ReadAsync()
        {
            var httpResponse = await _httpClient.GetAsync(_serviceUri);
            var respondeBody = await httpResponse.Content.ReadAsStringAsync();
            if (_useJsonFormat)
                return _shapeFormatMapper.MapFromJsonFormat(respondeBody);

            return _shapeFormatMapper.MapFromCustomFormat(respondeBody);
        }

        public async Task WriteAsync(IEnumerable<IShape> shapes)
        {
            string contentToSend;

            if (_useJsonFormat)
                contentToSend = _shapeFormatMapper.MapToJsonFormat(shapes);
            else
                contentToSend = _shapeFormatMapper.MapToCustomFormat(shapes);

            await _httpClient.PostAsync(_serviceUri, new StringContent(contentToSend));

        }
    }
}
