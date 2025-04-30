using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleProductRepository
{
    Task<SaleProduct> CreateAsync(SaleProduct saleProduct, CancellationToken cancellationToken = default);
    Task<SaleProduct?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
