using SrBackendMillon.Application.DTOs;

namespace SrBackendMillon.Application.Abstractions
{
    public interface IPropertyService
    {
        Task<PropertyReadDto> CreatePropertyAsync(PropertyCreateDto dto, CancellationToken ct = default);
        Task<PropertyReadDto?> GetPropertyByIdAsync(string id, CancellationToken ct = default);
        Task<IReadOnlyList<PropertyReadDto>> GetAllPropertiesAsync(CancellationToken ct = default);
    }
}
