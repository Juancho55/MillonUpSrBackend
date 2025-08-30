using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace SrBackendMillon.Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly GridFSBucket _bucket;

        public ImageRepository(IMongoDatabase database)
        {
            _bucket = new GridFSBucket(database, new GridFSBucketOptions
            {
                BucketName = "images"
            });
        }

        public async Task<string> UploadImageAsync(string base64, CancellationToken ct = default)
        {
            var bytes = Convert.FromBase64String(base64);
            var id = await _bucket.UploadFromBytesAsync(Guid.NewGuid().ToString(), bytes, null, ct);
            return id.ToString();
        }

        public async Task<byte[]?> GetImageAsync(string id, CancellationToken ct = default)
        {
            try
            {
                var objectId = new MongoDB.Bson.ObjectId(id);
                return await _bucket.DownloadAsBytesAsync(objectId, cancellationToken: ct);
            }
            catch (GridFSFileNotFoundException)
            {
                return null;
            }
        }
    }
}
