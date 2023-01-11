namespace NegoSudApi.Models;

public class BottleGrape : IModelBase
{
    public int Grape_Id { get; set; }
    public int Bottle_Id { get; set; }
    public int? Grape_Percentage { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public string? Created_By { get; set; }
    public string? Updated_By { get; set; }

    public virtual Bottle Bottle { get; set; }
    public virtual Grape Grape { get; set; }
}