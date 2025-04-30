using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class PurchaseOrderProductRepository : IPurchaseOrderProductRepository
{
    private readonly DefaultContext _context;

    public PurchaseOrderProductRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<PurchaseOrderProduct> CreateAsync(PurchaseOrderProduct purchaseOrderProduct, CancellationToken cancellationToken = default)
    {
        await _context.PurchaseOrderProducts.AddAsync(purchaseOrderProduct, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return purchaseOrderProduct;
    }

    public async Task<PurchaseOrderProduct?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.PurchaseOrderProducts.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var purchaseOrderProduct = await GetByIdAsync(id, cancellationToken);
        if (purchaseOrderProduct == null)
            return false;

        _context.PurchaseOrderProducts.Remove(purchaseOrderProduct);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
