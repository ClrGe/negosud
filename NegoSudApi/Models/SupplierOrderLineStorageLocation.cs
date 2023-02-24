namespace NegoSudApi.Models;

public class SupplierOrderLineStorageLocation
{
    public SupplierOrderLine? SupplierOrderLine { get; set; }
    public StorageLocation? StorageLocation { get; set; }
    public int SupplierOrderLineId { get; set; }
    public int StorageLocationId { get; set; }
}