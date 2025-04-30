using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface IPurchaseOrderRepository
{
    Task<PurchaseOrder> CreateAsync(PurchaseOrder purchaseOrder, CancellationToken cancellationToken = default);
    Task<PurchaseOrder?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
