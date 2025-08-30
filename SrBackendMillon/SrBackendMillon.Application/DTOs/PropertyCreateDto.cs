namespace SrBackendMillon.Application.DTOs
{
    public sealed record PropertyCreateDto(string Name, string Address, decimal Price, string ImageId);
}
