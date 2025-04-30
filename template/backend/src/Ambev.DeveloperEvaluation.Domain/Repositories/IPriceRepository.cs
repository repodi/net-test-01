using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IPriceRepository
{
    Task<Price> CreateAsync(Price price, CancellationToken cancellationToken = default);
    Task<Price?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
