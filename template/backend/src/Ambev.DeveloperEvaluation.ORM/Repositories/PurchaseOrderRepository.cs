using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class PurchaseOrderRepository : IPurchaseOrderRepository
{
    private readonly DefaultContext _context;

    public PurchaseOrderRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<PurchaseOrder> CreateAsync(PurchaseOrder purchaseOrder, CancellationToken cancellationToken = default)
    {
        await _context.PurchaseOrders.AddAsync(purchaseOrder, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return purchaseOrder;
    }

    public async Task<PurchaseOrder?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.PurchaseOrders.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var purchaseOrder = await GetByIdAsync(id, cancellationToken);
        if (purchaseOrder == null)
            return false;

        _context.PurchaseOrders.Remove(purchaseOrder);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
