namespace NegoSudApi.Models
{
    public class CustomerOrderLine : IModelBase
    {
        public DateTime? Created_At { get ; set ; }
        public DateTime? Updated_At { get ; set; }
        public string? Created_By { get; set; }
        public string? Updated_By { get; set; }
        public int Id { get; set; }
        public decimal? Quantity { get; set; }
        public virtual Bottle? Bottle { get; set; }
        public virtual CustomerOrder? CustomerOrder { get; set; }
    }
}
