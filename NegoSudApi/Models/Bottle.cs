namespace NegoSudApi.Models;

public class Bottle : IModelBase
{
    public int Id { get; set; }
    public string Full_Name { get; set; }
    public string Label { get; set; }
    public decimal Volume { get; set; }
    public byte[] Picture { get; set; }
    public int Year_Produced { get; set; }
    public decimal Alcohol_Percentage { get; set; }
    public decimal Current_Price { get; set; }
    public int Producer_Id { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public string Created_By { get; set; }
    public string Updated_By { get; set; }

    public virtual ICollection<Storage> Locations { get; set; }
    public virtual ICollection<BottleGrape> Grapes { get; set; }
    public virtual  Producer Producer { get; set; }
}