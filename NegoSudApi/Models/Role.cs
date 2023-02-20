using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class Role : IModelBase
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public virtual ICollection<Permission>? Permissions { get; set; }
    public virtual ICollection<User>? Users { get; set; }
}