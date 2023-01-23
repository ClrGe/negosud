namespace NegoSudApi.Models;

public class BottleStorageLocation : IModelBase
{
    public int StorageLocation_Id { get; set; }
    public int Bottle_Id { get; set; }
    public int? Quantity { get; set; }
    public DateTime? Created_At { get; set; }
    public DateTime? Updated_At { get; set; }
    public string? Created_By { get; set; }
    public string? Updated_By { get; set; }
    
    public virtual StorageLocation? StorageLocation { get; set; }
    public virtual Bottle? Bottle { get; set; }

}