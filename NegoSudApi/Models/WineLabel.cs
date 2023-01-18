using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models
{
    public class WineLabel : IModelBase
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public virtual IEnumerable<Bottle>? Bottles { get; set; }

    }
}
