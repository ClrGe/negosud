namespace NegoSudPostgreSql.Models;

public class Producer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Details { get; set; }
    public int Region_Id { get; set; }

    public ICollection<Region> Regions { get; } = new List<Region>();

}