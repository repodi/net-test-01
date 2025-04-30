using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


public class Price : BaseEntity
{
    public Guid? ProductId { get; set; }
    public Guid? UnitId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public Price()
    {
        CreatedAt = DateTime.UtcNow;
    }

    
}