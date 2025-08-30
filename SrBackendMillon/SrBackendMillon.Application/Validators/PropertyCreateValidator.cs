using FluentValidation;
using SrBackendMillon.Application.DTOs;

namespace SrBackendMillon.Application.Validators
{
    public sealed class PropertyCreateValidator : AbstractValidator<PropertyCreateDto>
    {
        public PropertyCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address must not exceed 200 characters.");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(x => x.ImageId)
                .NotEmpty().WithMessage("Image is required.")
                .Must(BeAValidBase64).WithMessage("Image must be a valid Base64 string.");
        }

        private bool BeAValidBase64(string base64String)
        {
            if (string.IsNullOrWhiteSpace(base64String))
                return false;

            Span<byte> buffer = new Span<byte>(new byte[base64String.Length]);
            return Convert.TryFromBase64String(base64String, buffer, out _);
        }
    }
}
