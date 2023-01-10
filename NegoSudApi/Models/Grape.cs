namespace NegoSudApi.Models;

public class Grape : IModelBase
{
    public int Id { get; set; }
    public string Grape_Type { get; set; }
    public string Wine_Type { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public string Created_By { get; set; }
    public string Updated_By { get; set; }
    public virtual ICollection<BottleGrape> Bottles { get; set; }



}