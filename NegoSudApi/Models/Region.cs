namespace NegoSudApi.Models;

public class Region : IModelBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Country_Id { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public string Created_By { get; set; }
    public string Updated_By { get; set; }

    public virtual ICollection<Producer> Producers { get; set; }
    public virtual Country Country { get; set; }
}