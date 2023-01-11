namespace NegoSudApi.Models;

public class Grape : IModelBase
{
    public int Id { get; set; }
    public string? Grape_Type { get; set; }
    public string? Wine_Type { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
    public string? Created_By { get; set; }
    public string? Updated_By { get; set; }
    public virtual ICollection<BottleGrape> BottleGrapes { get; set; }



}