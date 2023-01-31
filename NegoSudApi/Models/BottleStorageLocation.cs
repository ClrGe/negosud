using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class BottleStorageLocation : IModelBase
{
    public int StorageLocationId { get; set; }
    public int BottleId { get; set; }
    public int? Quantity { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    
    public virtual StorageLocation? StorageLocation { get; set; }
    public virtual Bottle? Bottle { get; set; }

}