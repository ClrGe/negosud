using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class StorageLocation : IModelBase
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
   
    public virtual ICollection<BottleStorageLocation>? BottleStorageLocations { get; set; }
    public virtual ICollection<CustomerOrderLineStorageLocation>? CustomerOrderLineStorageLocations { get; set; }
    public virtual ICollection<SupplierOrderLineStorageLocation>? SupplierOrderLineStorageLocations { get; set; }

}