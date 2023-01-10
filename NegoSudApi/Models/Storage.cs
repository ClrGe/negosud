namespace NegoSudApi.Models;

public class Storage
{
    public int Id { get; set; }
    public int Location_Id { get; set; }
    public int Bottle_Id { get; set; }
    public int Quantity { get; set; }

    public virtual ICollection<Bottle> Bottles { get; } = new List<Bottle>();
    public virtual ICollection<Location> Locations { get; } = new List<Location>();
}