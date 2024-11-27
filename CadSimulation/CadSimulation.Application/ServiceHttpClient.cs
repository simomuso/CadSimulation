namespace CadSimulation.Application
{
    public interface IServiceHttpClient
    {
        Task<string> GetAsync();
        Task SaveAsync(string content);
    }

    public class ServiceHttpClient : IServiceHttpClient
    {
        private readonly Uri _serviceUri;
        private readonly HttpClient _httpClient = new();

        public ServiceHttpClient(Uri serviceUri)
        {
            _serviceUri = serviceUri;
        }

        public async Task<string> GetAsync()
        {
            var response = await _httpClient.GetAsync(_serviceUri);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task SaveAsync(string content)
        {
            await _httpClient.PostAsync(_serviceUri, new StringContent(content));
        }
    }
}
