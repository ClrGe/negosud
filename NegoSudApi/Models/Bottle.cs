using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class Bottle : IModelBase
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Description { get; set; }
    public decimal? Volume { get; set; }
    public string? Picture { get; set; }
    public int? YearProduced { get; set; }
    public decimal? AlcoholPercentage { get; set; }
    public decimal? CurrentPrice { get; set; }
    public string? WineType { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    
    public virtual ICollection<BottleStorageLocation>? BottleStorageLocations { get; set; }
    public virtual ICollection<BottleGrape>? BottleGrapes { get; set; }
    public virtual ICollection<BottleSupplier>? BottleSuppliers { get; set; }
    public virtual Producer? Producer { get; set; }
    public virtual WineLabel? WineLabel { get; set; }
}