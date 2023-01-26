namespace NegoSudApi.Models
{
    public class SupplierOrder : IModelBase
    {
        public DateTime? Created_At { get ; set ; }
        public DateTime? Updated_At { get ; set; }
        public DateTime? Cancelled_At { get ; set; }
        public string? Created_By { get; set; }
        public string? Updated_By { get; set; }
        public string? Cancelled_By { get; set; }
        public int Id { get; set; }
        public string? Reference { get; set; }
        public string? Description { get; set; }
        public DateTime? Date_Order { get; set; }
        public DateTime? Date_Delivery { get; set; }

        public virtual Producer? Producer { get; set; }
        public virtual ICollection<SupplierOrderLine>? Lines { get; set; }
    }
}
