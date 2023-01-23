using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class Address : IModelBase
{
    public int Id { get; set; }
    public string? Label { get; set; }
    public string? FirstLine { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public virtual City? City { get; set; }
    public int? UserId { get; set; } 
       
}