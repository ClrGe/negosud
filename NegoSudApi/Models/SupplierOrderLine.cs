using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class SupplierOrderLine : IModelBase, IOrderLine
{
    public int Id { get; set; }
    public int? Quantity { get; set; }
    public int? BottleId { get; set; }
    public int? SupplierOrderId { get; set; }
    public DateTime? CreatedAt { get ; set ; }
    public DateTime? UpdatedAt { get ; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public virtual SupplierOrder? SupplierOrder { get; set; }
    public virtual Bottle? Bottle { get; set; }
}