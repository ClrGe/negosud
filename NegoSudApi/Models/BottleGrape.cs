using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class BottleGrape : IModelBase
{
    public int GrapeId { get; set; }
    public int BottleId { get; set; }
    public decimal? GrapePercentage { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public virtual Bottle? Bottle { get; set; }
    public virtual Grape? Grape { get; set; }
}