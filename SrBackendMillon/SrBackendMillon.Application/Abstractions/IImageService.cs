namespace SrBackendMillon.Application.Abstractions
{
    public interface IImageService
    {
        Task<byte[]?> GetImageAsync(string id, CancellationToken ct = default);
    }
}
