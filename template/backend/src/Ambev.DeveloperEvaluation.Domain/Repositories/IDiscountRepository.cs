using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IDiscountRepository
{
    Task<Discount> CreateAsync(Discount discount, CancellationToken cancellationToken = default);
    Task<Discount?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
