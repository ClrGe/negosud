namespace NegoSudApi.Models;

/// <summary>
/// This interface describe the creation time and user, as much as the updated time and by who
/// </summary>
public interface IModelBase
{
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public string Created_By { get; set; }
    public string Updated_By { get; set; }
    
}