using System.ComponentModel.DataAnnotations;
using FluentValidation;
using SrBackendMillon.Application.Abstractions;
using SrBackendMillon.Application.DTOs;
using SrBackendMillon.Application.Mapping;
using SrBackendMillon.Infrastructure.Repositories;
using ValidationException = FluentValidation.ValidationException;

namespace SrBackendMillon.Application.Services
{
    public sealed class PropertyService : IPropertyService, IImageService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IValidator<PropertyCreateDto> _createValidator;

        public PropertyService(IPropertyRepository propertyRepository, IImageRepository imageRepository, IValidator<PropertyCreateDto> createValidator)
        {
            _propertyRepository = propertyRepository;
            _imageRepository = imageRepository;
            _createValidator = createValidator;
        }

        public async Task<PropertyReadDto> CreatePropertyAsync(PropertyCreateDto dto, CancellationToken ct = default)
        {

            var validation = await _createValidator.ValidateAsync(dto, ct);

            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var imageId = await _imageRepository.UploadImageAsync(dto.ImageId, ct);

            await _createValidator.ValidateAndThrowAsync(dto, cancellationToken: ct);
            var entity = new Domain.Entities.Property(new Guid().ToString(), dto.Name, dto.Address, dto.Price, imageId);
            await _propertyRepository.InsertAsync(entity, ct);
            return new PropertyReadDto(entity.Id, entity.Name, entity.Address, entity.Price, entity.ImageId);
        }

        public async Task<IReadOnlyList<PropertyReadDto>> GetAllPropertiesAsync(CancellationToken ct = default)
            => (await _propertyRepository.GetAllAsync(ct))
                .Select(x => x.ToReadDto())
                .ToList();

        public async Task<byte[]?> GetImageAsync(string id, CancellationToken ct = default)
         => (await _imageRepository.GetImageAsync(id, ct));

        public async Task<PropertyReadDto?> GetPropertyByIdAsync(string id, CancellationToken ct = default)
         => (await _propertyRepository.GetByIdAsync(id, ct))?.ToReadDto();
    }
}
