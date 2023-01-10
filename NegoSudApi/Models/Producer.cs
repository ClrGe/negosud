namespace NegoSudApi.Models;

public class Producer : IModelBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Details { get; set; }
    public int Region_Id { get; set; }

    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public string Created_By { get; set; }
    public string Updated_By { get; set; }
    
    public virtual ICollection<Bottle> Bottles { get; set; }
    public virtual Region Region { get; set; }
}