
using MongoDB.Bson;
using MongoDB.Driver;
using SrBackendMillon.Domain.Entities;
using SrBackendMillon.Infrastructure.Config;
using SrBackendMillon.Infrastructure.Persistence;

namespace SrBackendMillon.Infrastructure.Repositories
{
    public sealed class MongoPropertyRepository : IPropertyRepository
    {
        private readonly IMongoCollection<Domain.Entities.Property> _collection;

        public MongoPropertyRepository(IMongoCollectionFactory factory, MongoSettings settings)
        {
            _collection = factory.Create<Domain.Entities.Property>(settings.PropertiesCollectionName);
        }

        public async Task<IReadOnlyList<Property>> GetAllAsync(CancellationToken ct = default)
        {
            return await _collection.Find(Builders<Property>.Filter.Empty).ToListAsync(ct);
        }

        public async Task<Property?> GetByIdAsync(string id, CancellationToken ct = default)
        {
            var cursor = await _collection.FindAsync(x => x.Id == id, cancellationToken: ct);
            return await cursor.FirstOrDefaultAsync(ct);
        }

        public async Task InsertAsync(Domain.Entities.Property property, CancellationToken ct = default)
        {
            property.GetType().GetProperty("Id")!.SetValue(property, ObjectId.GenerateNewId().ToString());
            await _collection.InsertOneAsync(property, null, ct);
        }
    }
}
