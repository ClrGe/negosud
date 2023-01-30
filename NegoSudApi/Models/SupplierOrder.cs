using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models
{
    public class SupplierOrder : IModelBase
    {
        public DateTime? CreatedAt { get ; set ; }
        public DateTime? UpdatedAt { get ; set; }
        public DateTime? CancelledAt { get ; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CancelledBy { get; set; }
        public int Id { get; set; }
        public string? Reference { get; set; }
        public string? Description { get; set; }
        public DateTime? DateOrder { get; set; }
        public DateTime? DateDelivery { get; set; }

        public virtual Producer? Producer { get; set; }
        public virtual ICollection<SupplierOrderLine>? Lines { get; set; }
    }
}
