namespace CadSimulation.Application.Repositories
{
    internal class ShapesRepositoryFactory : IShapesRepositoryFactory
    {
        public IShapesRepository CreateShapesRepository(string filePath, bool jsonFormatRequired)
        {
            if (jsonFormatRequired)
                return new JsonShapesRepository(filePath);

            return new CustomShapesRepository(filePath);
        }
    }

    internal interface IShapesRepositoryFactory
    {
        IShapesRepository CreateShapesRepository(string filePath, bool jsonFormatRequired);
    }
}
