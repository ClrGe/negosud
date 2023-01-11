namespace NegoSudApi.Models;

public class Region : IModelBase
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
    public string? Created_By { get; set; }
    public string? Updated_By { get; set; }

    public virtual ICollection<Producer> Producers { get; set; }
    public virtual Country Country { get; set; }
}