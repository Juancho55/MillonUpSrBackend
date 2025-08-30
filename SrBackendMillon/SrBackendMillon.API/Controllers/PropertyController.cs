using Microsoft.AspNetCore.Mvc;
using SrBackendMillon.Application.Abstractions;
using SrBackendMillon.Application.DTOs;

namespace SrBackendMillon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _service;
        private readonly IImageService _imageService;

        public PropertyController(IPropertyService service, IImageService imageService)
        {
            _service = service;
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<ActionResult<PropertyReadDto>> CreatePropertyAsync([FromBody] Application.DTOs.PropertyCreateDto dto, CancellationToken ct = default)
        {
            var property = await _service.CreatePropertyAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id = property.Id }, property);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PropertyReadDto>>> GetAllAsync(CancellationToken ct = default)
        {
            var properties = await _service.GetAllPropertiesAsync(ct);
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyReadDto>> GetById(string id, CancellationToken ct = default)
        {
            var property = await _service.GetPropertyByIdAsync(id, ct);
            if (property is null)
            {
                return NotFound();
            }
            return Ok(property);
        }

        [HttpGet("image/{id}")]
        public async Task<IActionResult> GetImageAsync(string id, CancellationToken ct = default)
        {
            var imageData = await _imageService.GetImageAsync(id, ct);
            if (imageData is null)
            {
                return NotFound();
            }
            return File(imageData, "image/jpeg");
        }

    }
}
