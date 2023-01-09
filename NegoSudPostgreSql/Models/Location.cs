namespace NegoSudPostgreSql.Models;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual Inventory Inventory { get; set; }
}