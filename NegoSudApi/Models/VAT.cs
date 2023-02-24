namespace NegoSudApi.Models;

public class VAT
{
    public int Id { get; set; }
    public decimal? Value { get; set; }
    public virtual ICollection<Bottle>? Bottles { get; set; }
}