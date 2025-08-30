using MongoDB.Driver;

namespace SrBackendMillon.Infrastructure.Persistence
{
    public interface IMongoCollectionFactory
    {
        IMongoCollection<T> Create<T>(string collectionName);
    }
    public sealed class MongoCollectionFactory : IMongoCollectionFactory
    {
        private readonly IMongoDatabase _database;
        public MongoCollectionFactory(IMongoDatabase database)
        {
            _database = database;
        }
        public IMongoCollection<T> Create<T>(string collectionName) =>
            _database.GetCollection<T>(collectionName);

    }
}
