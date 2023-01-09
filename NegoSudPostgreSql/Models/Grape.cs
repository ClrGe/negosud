namespace NegoSudPostgreSql.Models;

public class Grape
{
    public int Id { get; set; }
    public string Grape_Type { get; set; }
    public string Wine_Type { get; set; }
    
    public virtual Bottle Bottle { get; set; }
}