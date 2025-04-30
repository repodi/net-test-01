using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


public class Discount : BaseEntity
{
    public int MinimumUnits { get; set; }
    public decimal DiscountPercentage { get; set; }    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Discount()
    {
        CreatedAt = DateTime.UtcNow;
    }

    
}