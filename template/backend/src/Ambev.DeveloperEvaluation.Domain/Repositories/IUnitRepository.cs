using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IUnitRepository
{
    Task<Unit> CreateAsync(Unit unit, CancellationToken cancellationToken = default);
    Task<Unit?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
