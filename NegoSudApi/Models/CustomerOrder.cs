using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class CustomerOrder : IModelBase
{
    public int Id { get; set; }
    public string? Reference { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedAt { get ; set ; }
    public DateTime? UpdatedAt { get ; set; }
    public DateTime? CancelledAt { get ; set; }
    public DateTime? Date_Order { get; set; }
    public DateTime? Date_Delivery { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public string? CancelledBy { get; set; }
    public virtual Address? DeliveryAddress { get; set; }
    public virtual User? Customer { get; set; }
    public virtual ICollection<CustomerOrderLine>? Lines { get; set; }
}