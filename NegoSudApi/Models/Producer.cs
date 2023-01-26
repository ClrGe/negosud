using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class Producer : IModelBase
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Details { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    
    public virtual ICollection<Bottle>? Bottles { get; set; }
    public virtual Region? Region { get; set; }
    public virtual Address? Address { get; set; }
}