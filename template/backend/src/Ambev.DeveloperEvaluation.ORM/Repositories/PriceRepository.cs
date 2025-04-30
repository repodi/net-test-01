using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class PriceRepository : IPriceRepository
{
    private readonly DefaultContext _context;

    public PriceRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Price> CreateAsync(Price price, CancellationToken cancellationToken = default)
    {
        await _context.Prices.AddAsync(price, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return price;
    }

    public async Task<Price?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Prices.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var price = await GetByIdAsync(id, cancellationToken);
        if (price == null)
            return false;

        _context.Prices.Remove(price);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
