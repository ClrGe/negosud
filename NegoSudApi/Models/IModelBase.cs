namespace NegoSudApi.Models;

public interface IModelBase
{
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public string Created_By { get; set; }
    public string Updated_By { get; set; }
    
}