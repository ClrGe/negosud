namespace NegoSudPostgreSql.Models;

public class Bottle
{
    public int Id { get; set; }
    public string Full_Name { get; set; }
    public string Label { get; set; }
    public decimal Volume { get; set; }
    public byte[] Picture { get; set; }
    public int Year_Produced { get; set; }
    public decimal Alcohol_Percentage { get; set; }
    public decimal Current_Price { get; set; }
    public int Grape_Id { get; set; }
    public int Producer_Id { get; set; }
    public int Inventory_Id { get; set; }
    
    public virtual Inventory Inventory { get; set; }
    public virtual ICollection<Grape> Grapes { get;  } = new List<Grape>();
    public virtual ICollection<Producer> Producers { get;  } = new List<Producer>();
}