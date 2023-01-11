namespace NegoSudApi.Models;

public class BottleLocation : IModelBase
{
    public int Location_Id { get; set; }
    public int Bottle_Id { get; set; }
    public int? Quantity { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public string? Created_By { get; set; }
    public string? Updated_By { get; set; }
    
    public virtual Location Location { get; set; }
    public virtual Bottle Bottle { get; set; }

}