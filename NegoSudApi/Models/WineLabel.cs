namespace NegoSudApi.Models
{
    public class WineLabel : IModelBase
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public string? Created_By { get; set; }
        public string? Updated_By { get; set; }

        public virtual IEnumerable<Bottle>? Bottles { get; set; }
    }
}
