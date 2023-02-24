namespace NegoSudApi.Models;

public class CustomerOrderLineStorageLocation
{
    public CustomerOrderLine? CustomerOrderLine { get; set; }
    public StorageLocation? StorageLocation { get; set; }
    public int CustomerOrderLineId { get; set; }
    public int StorageLocationId { get; set; }
}