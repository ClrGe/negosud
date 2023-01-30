using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class BottleSupplier : IModelBase
{
    public int BottleId { get; set; }
    public int SupplierId { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    
    public virtual Bottle? Bottle { get; set; }
    public virtual Supplier? Supplier { get; set; }
}