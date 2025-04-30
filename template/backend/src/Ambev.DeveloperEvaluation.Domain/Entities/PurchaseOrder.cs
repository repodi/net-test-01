using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


public class PurchaseOrder : BaseEntity
{
    public Guid CustomerId { get; set; }
    public Guid? CustomerUserId { get; set; }
    public Guid? BranchId { get; set; }
    public Guid? BranchUserId { get; set; }
    public long Number { get; set; }
    public string RecommendedSellerCode { get; set; } = string.Empty;
    public string Information { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool Cancelled { get; set; }
    public DateTime? CancelledAt { get; set; }
    public bool Open { get; set; }
    public DateTime? ClosedAt { get; set; }

    public PurchaseOrder()
    {
        CreatedAt = DateTime.UtcNow;
    }

    
}