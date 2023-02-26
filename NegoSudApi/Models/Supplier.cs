using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class Supplier : IModelBase
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Details { get; set; }
    public string? Email { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public virtual ICollection<BottleSupplier>? BottleSuppliers { get; set; }
    public virtual Address? Address { get; set; }
}