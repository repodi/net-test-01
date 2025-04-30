using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleProductRepository : ISaleProductRepository
{
    private readonly DefaultContext _context;

    public SaleProductRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<SaleProduct> CreateAsync(SaleProduct saleProduct, CancellationToken cancellationToken = default)
    {
        await _context.SaleProducts.AddAsync(saleProduct, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return saleProduct;
    }

    public async Task<SaleProduct?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.SaleProducts.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var saleProduct = await GetByIdAsync(id, cancellationToken);
        if (saleProduct == null)
            return false;

        _context.SaleProducts.Remove(saleProduct);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
