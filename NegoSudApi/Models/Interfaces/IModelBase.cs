namespace NegoSudApi.Models.Interfaces;

/// <summary>
/// This interface describe the creation time and user, as much as the updated time and by who
/// </summary>
public interface IModelBase
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    
}