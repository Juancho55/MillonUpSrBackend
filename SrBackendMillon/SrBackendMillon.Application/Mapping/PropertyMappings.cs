using SrBackendMillon.Application.DTOs;

namespace SrBackendMillon.Application.Mapping
{
    public static class PropertyMappings
    {
        public static PropertyReadDto ToReadDto(this Domain.Entities.Property property)
            => new PropertyReadDto(property.Id, property.Name, property.Address, property.Price, property.ImageId);
    }
}
