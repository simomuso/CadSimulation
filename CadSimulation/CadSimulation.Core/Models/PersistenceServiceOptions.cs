namespace CadSimulation.Core.Models
{
    public interface IPersistenceServiceOptions
    {
        string FilesystemPath { get; set; }
        Uri? ServiceUri { get; set; }
        bool UseJsonFormat { get; set; }
    }

    public class PersistenceServiceOptions : IPersistenceServiceOptions
    {
        public string FilesystemPath { get; set; } = null!;
        public Uri? ServiceUri { get; set; } = null!;
        public bool UseJsonFormat { get; set; }
    }
}
