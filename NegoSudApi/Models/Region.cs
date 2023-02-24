using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class Region : IModelBase
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public int CountryId { get; set; }
    public virtual ICollection<Producer>? Producers { get; set; }
    public virtual Country? Country { get; set; }
}