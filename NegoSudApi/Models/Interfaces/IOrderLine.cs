namespace NegoSudApi.Models.Interfaces;

public interface IOrderLine
{
    public int Id { get; set; }
    public int? Quantity { get; set; }
    public Bottle? Bottle { get; set; }
}