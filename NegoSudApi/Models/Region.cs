namespace NegoSudApi.Models;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Country_Id { get; set; }

    public ICollection<Country> Countries { get; } = new List<Country>();
}