namespace CadSimulation.Application.Repositories
{
    public class PersistanceStrategySelector : IPersistencyStrategySelector
    {
        public IPersistanceStrategy SelectStrategy(ApplicationOptions options)
        {
            // If no persistance is selected, use in memory persistance
            if (string.IsNullOrWhiteSpace(options.FilesystemPath) && options.ServiceUri == null)
                return new InMemoryPersistanceStrategy();

            // If local persistence is configured and json format is selected, use it
            if(!string.IsNullOrWhiteSpace(options.FilesystemPath) && options.UseJsonFormat)
                return new LocalJsonPersistanceStrategy(options.FilesystemPath);

            // If local persistence is configured and no json format is selected, use custom format
            if (!string.IsNullOrWhiteSpace(options.FilesystemPath) && !options.UseJsonFormat)
                return new LocalCustomPersistanceStrategy(options.FilesystemPath);

            return new ExternalPersistanceStrategy(options.ServiceUri, options.UseJsonFormat);
        }
    }

    public interface IPersistencyStrategySelector
    {
        IPersistanceStrategy SelectStrategy(ApplicationOptions options);
    }
}
