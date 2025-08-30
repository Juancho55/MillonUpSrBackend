namespace SrBackendMillon.Infrastructure.Repositories
{
    public interface IImageRepository
    {
        Task<string> UploadImageAsync(string base64, CancellationToken ct = default);
        Task<byte[]?> GetImageAsync(string id, CancellationToken ct = default);
    }
}
