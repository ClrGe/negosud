using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class BottleLocation : IModelBase
{
    public int LocationId { get; set; }
    public int BottleId { get; set; }
    public int? Quantity { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    
    public virtual Location? Location { get; set; }
    public virtual Bottle? Bottle { get; set; }

}