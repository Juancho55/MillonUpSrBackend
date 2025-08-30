namespace SrBackendMillon.Infrastructure.Repositories
{
    public interface IPropertyRepository
    {
        Task InsertAsync(Domain.Entities.Property property, CancellationToken ct = default);
        Task<Domain.Entities.Property?> GetByIdAsync(string id, CancellationToken ct = default);
        Task<IReadOnlyList<Domain.Entities.Property>> GetAllAsync(CancellationToken ct = default);
    }
}
