using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class CustomerOrderLine : IModelBase, IOrderLine
{
    public int Id { get; set; }
    public int? Quantity { get; set; }
    public virtual Bottle? Bottle { get; set; }
    public DateTime? CreatedAt { get ; set ; }
    public DateTime? UpdatedAt { get ; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public ICollection<CustomerOrderLineStorageLocation>? CustomerOrderLineStorageLocations { get; set; } = new List<CustomerOrderLineStorageLocation>();
    public virtual CustomerOrder? CustomerOrder { get; set; }
}