namespace SrBackendMillon.Application.DTOs
{
    public sealed record PropertyReadDto(string Id, string Name, string Address, decimal Price, string ImageId);
}
