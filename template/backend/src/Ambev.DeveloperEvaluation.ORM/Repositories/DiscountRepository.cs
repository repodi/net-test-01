using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly DefaultContext _context;

    public DiscountRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Discount> CreateAsync(Discount discount, CancellationToken cancellationToken = default)
    {
        await _context.Discounts.AddAsync(discount, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return discount;
    }

    public async Task<Discount?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Discounts.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var discount = await GetByIdAsync(id, cancellationToken);
        if (discount == null)
            return false;

        _context.Discounts.Remove(discount);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
