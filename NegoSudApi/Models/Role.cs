using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class Role : IModelBase
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? PermissionId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public virtual Permission? Permission { get; set; }
}