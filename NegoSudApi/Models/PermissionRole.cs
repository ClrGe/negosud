using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class PermissionRole : IModelBase
{
    public int PermissionId { get; set; }
    public virtual Permission? Permission { get; set; }
    public int RoleId { get; set; }
    public virtual Role? Role { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
}

