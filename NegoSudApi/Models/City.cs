using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class City : IModelBase
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? ZipCode { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public int? CountryId { get; set; }
    public Country? Country { get; set; }
    public virtual ICollection<Address>? Addresses { get; set; }
      
}