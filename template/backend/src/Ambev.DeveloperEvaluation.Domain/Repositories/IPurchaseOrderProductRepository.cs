using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IPurchaseOrderProductRepository
{
    Task<PurchaseOrderProduct> CreateAsync(PurchaseOrderProduct purchaseOrderProduct, CancellationToken cancellationToken = default);
    Task<PurchaseOrderProduct?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
