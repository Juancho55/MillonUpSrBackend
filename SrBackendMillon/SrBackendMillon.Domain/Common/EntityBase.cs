namespace SrBackendMillon.Domain.Common
{
    public abstract class EntityBase
    {
        public string Id { get; protected set; } = string.Empty;
        public DateTime CreatedAtUtc { get; protected set; } = DateTime.UtcNow;
        public DateTime? UpdatedAtUtc { get; protected set; }

        public void TouchUpdated() => UpdatedAtUtc = DateTime.UtcNow;

    }
}
