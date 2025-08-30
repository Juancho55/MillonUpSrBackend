using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SrBackendMillon.Domain.Common;


namespace SrBackendMillon.Domain.Entities
{
    public sealed class Property : EntityBase
    {        
        public string IdOwner { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ImageId { get; private set; } = string.Empty;

        private Property() { }

        public Property(string idOwner, string name, string address, decimal price, string imageId)
        {
            IdOwner = idOwner;
            Name = name;
            Address = address;
            Price = price;
            ImageId = imageId;
        }

        public void Update(string name, string address, decimal price, string imageId)
        {
            if (!string.IsNullOrEmpty(Name)) Name = name;
            if (!string.IsNullOrEmpty(Address)) Address = address;
            if (Price >= 0) Price = price;
            ImageId = imageId;
            TouchUpdated();
        }

    }
}
