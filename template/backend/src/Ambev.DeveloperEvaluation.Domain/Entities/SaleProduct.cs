using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


public class SaleProduct : BaseEntity
{
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public Guid PriceId { get; set; }
    public Guid UnitId { get; set; }
    public decimal DiscountPercentage { get; set; }
    public int Quantity { get; set; }
    public decimal FullPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public SaleProduct()
    {
        CreatedAt = DateTime.UtcNow;
    }

    
}