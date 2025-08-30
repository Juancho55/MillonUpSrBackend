namespace SrBackendMillon.Infrastructure.Config
{
    public sealed class MongoSettings
    {
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
        public string PropertiesCollectionName { get; set; } = "Properties";
    }
}
