using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models
{
    public class SupplierOrderLine : IModelBase
    {
        public DateTime? CreatedAt { get ; set ; }
        public DateTime? UpdatedAt { get ; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public int Id { get; set; }
        public decimal? Quantity { get; set; }
        public virtual Bottle? Bottle { get; set; }
        public virtual SupplierOrder? SupplierOrder { get; set; }
    }
}
