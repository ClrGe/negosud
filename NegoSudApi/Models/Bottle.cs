namespace NegoSudApi.Models;

public class Bottle : IModelBase
{
    public int Id { get; set; }
    public string? Full_Name { get; set; }
    public string? Description { get; set; }
    public decimal? Volume { get; set; }
    public byte[]? Picture { get; set; }
    public int? Year_Produced { get; set; }
    public decimal? Alcohol_Percentage { get; set; }
    public decimal? Current_Price { get; set; }

    public DateTime? Created_At { get; set; }
    public DateTime? Updated_At { get; set; }
    public string? Created_By { get; set; }
    public string? Updated_By { get; set; }

    public virtual ICollection<BottleStorageLocation>? BottleStorageLocations { get; set; }
    public virtual ICollection<BottleGrape>? BottleGrapes { get; set; }
    public virtual Producer? Producer { get; set; }
    public virtual WineLabel? WineLabel { get; set; }
}