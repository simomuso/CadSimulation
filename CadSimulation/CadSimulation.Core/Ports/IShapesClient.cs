namespace CadSimulation.Core.Ports
{
    public interface IShapesClient
    {
        Task SendAsync(string metadata);
        Task<string> GetAsync();
    }
}
