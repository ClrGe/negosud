using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class Bottle : IModelBase
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Description { get; set; }
    public string? Label { get; set; }
    public decimal? Volume { get; set; }
    public byte[]? Picture { get; set; }
    public int? YearProduced { get; set; }
    public decimal? AlcoholPercentage { get; set; }
    public decimal? CurrentPrice { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public virtual ICollection<BottleLocation>? BottleLocations { get; set; }
    public virtual ICollection<BottleGrape>? BottleGrapes { get; set; }
    public virtual Producer? Producer { get; set; }
}